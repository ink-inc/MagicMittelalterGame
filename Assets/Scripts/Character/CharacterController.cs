using Character.Player;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour

    {
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

            if (playerController.CheckMoveableTerrain(
                new Vector3(playerController.playerCameraTransform.position.x,
                    playerController.playerCameraTransform.position.y - 1.7f,
                    playerController.playerCameraTransform.position.z), new Vector3(velocity.x, 0, velocity.z), 5f))
            {
                // makes sure, that the total veloctity is not higher while walking cross-ways
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

        private static void PlaySoundForMovement(PlayerController playerController, Vector3 velocity)
        {
            if (playerController.isRunning && velocity.magnitude > 0.1f && playerController.isAirborne == 0)
            {
                playerController.CharacterSounds.Running(playerController.groundDetector.GroundType);
            }
            else if (playerController.isSneaking && velocity.magnitude > 0.1f && playerController.isAirborne == 0)
            {
                playerController.CharacterSounds.Sneaking(playerController.groundDetector.GroundType);
            }
            //TODO: replace with isWalking flag
            else if (playerController.isAirborne == 0 && velocity.magnitude > 0.1f)
            {
                playerController.CharacterSounds.Walking(playerController.groundDetector.GroundType);
            }
            else
            {
                playerController.CharacterSounds.StopMovement();
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
    }
}