using Character.Player;
using Sounds.Manager;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CharacterSounds))]
    public class CharacterController : MonoBehaviour

    {
        private Rigidbody _rigidbody;
        public float isAirborne; // 0: on Ground; 1: on the way back down; 2: just jumped
        [Header("Player State Attributes")] public bool isRunning;

        public CharacterSounds CharacterSounds { get; set; }

        private void Start()
        {
            CharacterSounds = GetComponent<CharacterSounds>();
        }

        public void Movement(PlayerController playerController, float speed, float runMultiplier, float sneakMultiplier)
        {
            // TODO: fully convert to StatAttribute
            // get the actual speed with all modificators
            if (isRunning)
                speed *= runMultiplier;
            if (playerController.isSneaking)
                speed *= sneakMultiplier;

            // get the inputs
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // makes sure that sideway walking is slower than forward walking
            if (vertical < -0.01) speed *= 0.7f;

            Vector3 velocity = ((transform.forward * vertical) + (transform.right * horizontal));

            if (CheckWalkableTerrain(
                new Vector3(playerController.playerCameraTransform.position.x,
                    playerController.playerCameraTransform.position.y - 1.7f,
                    playerController.playerCameraTransform.position.z), new Vector3(velocity.x, 0, velocity.z), 5f))
            {
                // makes sure, that the total velocity is not higher while walking cross-ways
                if (velocity.magnitude > 1.01)
                {
                    float ySaver = velocity.y;
                    velocity.y = 0;
                    velocity = velocity.normalized;
                    velocity.y = ySaver;
                }

                // manages movement depending on being airborne or not
                if (isAirborne == 0)
                {
                    velocity *= speed;
                    velocity.y = _rigidbody.velocity.y;
                    _rigidbody.velocity = velocity;
                }
                else
                {
                    velocity *= speed;
                    velocity.y = 0;

                    _rigidbody.AddForce(velocity, ForceMode.Impulse);

                    // make sure, that the player is not able to be faster then the momentarily speed level is allowing him to be
                    velocity = _rigidbody.velocity;
                    velocity.y = 0;
                    velocity = velocity.normalized * Mathf.Clamp(velocity.magnitude, 0, speed);
                    velocity.y = _rigidbody.velocity.y;

                    _rigidbody.velocity = velocity;
                }
            }
            else
            {
                _rigidbody.velocity =
                    new Vector3(0f, 0f, 0f); // stops the player at an instant if the terrain is not movable
            }

            PlaySoundForMovement(playerController, velocity);
        }

        private void PlaySoundForMovement(PlayerController playerController, Vector3 velocity)
        {
            if (isRunning && velocity.magnitude > 0.1f && isAirborne == 0)
            {
                CharacterSounds.Running(playerController.groundDetector.GroundType);
            }
            else if (playerController.isSneaking && velocity.magnitude > 0.1f && isAirborne == 0)
            {
                CharacterSounds.Sneaking(playerController.groundDetector.GroundType);
            }
            //TODO: replace with isWalking flag
            else if (isAirborne == 0 && velocity.magnitude > 0.1f)
            {
                CharacterSounds.Walking(playerController.groundDetector.GroundType);
            }
            else
            {
                CharacterSounds.StopMovement();
            }
        }

        public void Rotation(float rotationX, PlayerController playerController,
            float sensitivity = 1f)
        {
            // get mouse Inputs
            rotationX = Mathf.Clamp(rotationX, -10, 10);

            Vector3 bodyRotation = new Vector3(0, rotationX, 0);
            playerController.body.Rotate(bodyRotation * sensitivity * Time.deltaTime, Space.Self);
        }

        public bool CheckWalkableTerrain(Vector3 position, Vector3 desiredDirection, float distance)
        {
            Ray slopeRay = new Ray(position, desiredDirection);

            if (!Physics.Raycast(slopeRay, out RaycastHit hit, distance)) return true;
            if (hit.collider.gameObject.tag is "Interactable") return true;
            // get the angle between the up vector and the hit game object
            float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
            if (!(slopeAngle > 45f)) return true;
            return !(hit.distance < 0.26f);
        }

        public void Jump(PlayerController playerController)
        {
            if (playerController.groundDetector.currentCollisions.Count == 0) return;
            Vector3 vel = new Vector3(_rigidbody.velocity.x, 0,
                _rigidbody.velocity.z);
            _rigidbody.velocity = vel;
            Vector3 jumpForce = new Vector3(0, playerController.playerProperties.jumpPower, 0);
            _rigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }
    }
}