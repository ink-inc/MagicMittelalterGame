using Character.Player;
using Sounds.Manager;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CharacterSounds))]
    public class CharacterController : MonoBehaviour

    {
        private GroundDetector _groundDetector;
        private Rigidbody _rigidbody;

        [Header("State Attributes")] public JumpStatus isAirborne;
        public bool isRunning;
        public bool isSneaking;

        public CharacterSounds Sounds { get; set; }

        protected virtual void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundDetector = GetComponentInChildren<GroundDetector>();
            Sounds = GetComponent<CharacterSounds>();
        }

        protected virtual void Update()
        {
            // check if the player in the Air or not
            isAirborne = _groundDetector.currentCollisions.Count == 0 ? JumpStatus.InAir : JumpStatus.OnGround;
        }

        public void Movement(float horizontal, float vertical, CharacterProperties properties)
        {
            float speed = properties.speed.Value;
            float runMultiplier = properties.runMultiplier;
            float sneakMultiplier = properties.sneakMultiplier;
            float sidewaysMultiplier = properties.sidewaysMultiplier;

            // TODO: fully convert to StatAttribute
            // get the actual speed with all modifications
            if (isRunning)
                speed *= runMultiplier;
            if (isSneaking)
                speed *= sneakMultiplier;

            // makes sure that sideways/backwards walking is slower than forward walking
            if (Mathf.Abs(horizontal) > 0.01 || vertical < -0.01)
                speed *= sidewaysMultiplier;

            Vector3 inputVelocity = (transform.forward * vertical) + (transform.right * horizontal);
            Vector3 inputPlaneVelocity = new Vector3(inputVelocity.x, 0, inputVelocity.z).normalized;

            if (CheckWalkableTerrain(_groundDetector.transform.position, inputPlaneVelocity, 5f))
            {
                // makes sure, that the total velocity is not higher while walking cross-ways
                if (inputVelocity.magnitude > 1.01)
                {
                    inputVelocity.x = inputPlaneVelocity.x;
                    inputVelocity.z = inputPlaneVelocity.z;
                }

                inputVelocity *= speed;

                // manages movement depending on being airborne or not
                if (isAirborne == JumpStatus.OnGround)
                {
                    inputVelocity.y = _rigidbody.velocity.y;
                    _rigidbody.velocity = inputVelocity;
                }
                else
                {
                    inputVelocity.y = 0;

                    _rigidbody.AddForce(inputVelocity, ForceMode.Impulse);

                    // make sure, that the player is not able to be faster then the momentarily speed level is allowing him to be
                    inputVelocity = _rigidbody.velocity;
                    inputVelocity.y = 0;
                    inputVelocity = inputVelocity.normalized * Mathf.Clamp(inputVelocity.magnitude, 0, speed);
                    inputVelocity.y = _rigidbody.velocity.y;

                    _rigidbody.velocity = inputVelocity;
                }
            }
            else
            {
                // stops the player at an instant if the terrain is not movable
                _rigidbody.velocity = Vector3.zero;
            }

            PlaySoundForMovement(inputVelocity);
        }

        private void PlaySoundForMovement(Vector3 velocity)
        {
            if (isRunning && velocity.magnitude > 0.1f && isAirborne == JumpStatus.OnGround)
            {
                Sounds.Running(_groundDetector.GroundType);
            }
            else if (isSneaking && velocity.magnitude > 0.1f && isAirborne == JumpStatus.OnGround)
            {
                Sounds.Sneaking(_groundDetector.GroundType);
            }
            //TODO: replace with isWalking flag
            else if (isAirborne == 0 && velocity.magnitude > 0.1f)
            {
                Sounds.Walking(_groundDetector.GroundType);
            }
            else
            {
                Sounds.StopMovement();
            }
        }

        public void Rotation(float rotationX, float sensitivity = 1f)
        {
            // get mouse Inputs
            rotationX = Mathf.Clamp(rotationX, -10, 10);

            Vector3 bodyRotation = new Vector3(0, rotationX, 0);
            transform.Rotate(bodyRotation * (sensitivity * Time.deltaTime), Space.Self);
        }

        public bool CheckWalkableTerrain(Vector3 position, Vector3 desiredDirection, float distance)
        {
            Ray slopeRay = new Ray(position, desiredDirection);

            if (!Physics.Raycast(slopeRay, out RaycastHit hit, distance))
                return true;
            if (hit.collider.gameObject.tag is "Interactable")
                return true;

            // get the angle between the up vector and the hit game object
            float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
            if (slopeAngle <= 45f)
                return true;
            return hit.distance >= 0.26f;
        }

        public void Jump(float jumpPower)
        {
            if (isAirborne != JumpStatus.OnGround)
                return;

            Vector3 vel = _rigidbody.velocity;
            vel.y = 0;
            _rigidbody.velocity = vel;

            _rigidbody.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
        }
    }
}