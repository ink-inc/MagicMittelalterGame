using Character.Player;
using Sounds.Manager;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterSounds))]
    public class CharacterController : MonoBehaviour

    {
        public CharacterSounds CharacterSounds { get; set; }


        private void Start()
        {
            CharacterSounds = GetComponent<CharacterSounds>();
        }

        public void Movement(PlayerController playerController)
        {
            // TODO: fully convert to StatAttribute
            // get the actual speed with all modificators
            float speed = playerController.playerProperties.speed.Value;
            if (playerController.isRunning)
                speed *= playerController.playerProperties.runMultiplier;
            if (playerController.isSneaking)
                speed *= playerController.playerProperties.sneakMultiplier;

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
                if (playerController.isAirborne == 0)
                {
                    velocity *= speed;
                    velocity.y = playerController.rigidbody.velocity.y;
                    playerController.rigidbody.velocity = velocity;
                }
                else
                {
                    velocity *= speed;
                    velocity.y = 0;

                    playerController.rigidbody.AddForce(velocity, ForceMode.Impulse);

                    // make sure, that the player is not able to be faster then the momentarily speed level is allowing him to be
                    velocity = playerController.rigidbody.velocity;
                    velocity.y = 0;
                    velocity = velocity.normalized * Mathf.Clamp(velocity.magnitude, 0, speed);
                    velocity.y = playerController.rigidbody.velocity.y;

                    playerController.rigidbody.velocity = velocity;
                }
            }
            else
            {
                playerController.rigidbody.velocity =
                    new Vector3(0f, 0f, 0f); // stops the player at an instant if the terrain is not movable
            }

            PlaySoundForMovement(playerController, velocity);
        }

        private void PlaySoundForMovement(PlayerController playerController, Vector3 velocity)
        {
            if (playerController.isRunning && velocity.magnitude > 0.1f && playerController.isAirborne == 0)
            {
                CharacterSounds.Running(playerController.groundDetector.GroundType);
            }
            else if (playerController.isSneaking && velocity.magnitude > 0.1f && playerController.isAirborne == 0)
            {
                CharacterSounds.Sneaking(playerController.groundDetector.GroundType);
            }
            //TODO: replace with isWalking flag
            else if (playerController.isAirborne == 0 && velocity.magnitude > 0.1f)
            {
                CharacterSounds.Walking(playerController.groundDetector.GroundType);
            }
            else
            {
                CharacterSounds.StopMovement();
            }
        }

        public void Rotation(float rotationX, float rotationY, PlayerController playerController)
        {
            // get mouse Inputs
            rotationX = Mathf.Clamp(rotationX, -10, 10);
            rotationY = Mathf.Clamp(rotationY, -10, 10);

            Vector3 bodyRotation = new Vector3(0, rotationX, 0);
            playerController.body.Rotate(bodyRotation * playerController.mouseSensitivity * Time.deltaTime, Space.Self);

            Vector3 cameraRotation = new Vector3(-rotationY, 0, 0);
            if (((playerController.playerCameraTransform.eulerAngles +
                  cameraRotation * playerController.mouseSensitivity * Time.deltaTime).x >= -90 &&
                 (playerController.playerCameraTransform.eulerAngles +
                  cameraRotation * playerController.mouseSensitivity * Time.deltaTime).x <= 90) ||
                ((playerController.playerCameraTransform.eulerAngles +
                  cameraRotation * playerController.mouseSensitivity * Time.deltaTime).x >= 270 &&
                 (playerController.playerCameraTransform.eulerAngles +
                  cameraRotation * playerController.mouseSensitivity * Time.deltaTime).x <= 450))
            {
                playerController.playerCameraTransform.Rotate(
                    cameraRotation * playerController.mouseSensitivity * Time.deltaTime, Space.Self);
            }
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
            Vector3 vel = new Vector3(playerController.rigidbody.velocity.x, 0,
                playerController.rigidbody.velocity.z);
            playerController.rigidbody.velocity = vel;
            Vector3 jumpForce = new Vector3(0, playerController.playerProperties.jumpPower, 0);
            playerController.rigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }
    }
}