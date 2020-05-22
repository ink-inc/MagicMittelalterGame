using System.Collections.Generic;
using System.Linq;
using Interaction;
using Sounds.Manager;
using TMPro;
using UnityEngine;

namespace Character.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        private CharacterController _characterController;

        private MusicManager _musicManager;
        private List<ISoundManager> _soundManagers;
        [Header("References")] public Transform body;

        public GameObject dialogueInterface;
        public GroundDetector groundDetector;
        public Interactor interactor;

        public Inventory inventory;


        [Header("Mouse settings")] public float mouseSensitivity;

        [Header("Menu References")] public PauseMenu pauseMenu;
        public Transform playerCameraTransform;
        public PlayerProperties playerProperties;
        public QuestjournalDisplay questDisplay;
        public TMP_InputField questjournalSearchbar;
        public Questlog questlog;
        public float sneakSlow = 0.7f;
        public float sprintBoost = 1.3f;


        private void Start()
        {
            playerCameraTransform.rotation = Quaternion.identity;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _characterController = GetComponent<CharacterController>();

            _musicManager = GetComponent<MusicManager>();

            _soundManagers = FindObjectsOfType<MonoBehaviour>().OfType<ISoundManager>().ToList();
        }

        private void Update()
        {
            // the only input detection that needs to be outside of the menu detection
            if (Input.GetKeyDown(KeyCode.O))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            if (Input.GetKeyDown(KeyCode.J) && !questjournalSearchbar.isFocused)
            {
                questDisplay.Toggle();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (CloseableMenu.openMenues.Count > 0) //If a menu is open
                {
                    CloseableMenu.openMenues.Peek().Hide(); //Hide menu at the top
                    _soundManagers.ForEach(manager => manager.Continue());
                }
                else
                {
                    FindAndPauseSounds();
                    pauseMenu.Show();
                }
            }

            // menu detection: If no menu is active, enable input
            if (Input.GetKeyDown(KeyCode.I))
                inventory.inventoryDisplay.Toggle();
            if (CloseableMenu.openMenues.Count == 0 && dialogueInterface.activeSelf == false)
            {
                // get all Inputs and calls the methods
                if (Input.GetButtonDown("Walk/Run"))
                    _characterController.isRunning = !_characterController.isRunning;
                if (Input.GetButtonDown("Jump")) _characterController.Jump(this);
                if (Input.GetButtonDown("Interact"))
                    interactor.KeyDown();
                if (Input.GetButtonDown("Sneak"))
                    ToggleSneak();

                _characterController.Movement(this, playerProperties.speed.Value,
                    playerProperties.runMultiplier, playerProperties.sneakMultiplier);
                float rotationY = Input.GetAxis("Mouse Y");
                _characterController.Rotation(Input.GetAxis("Mouse X"), this, mouseSensitivity);
                RotateCamera(rotationY);
            }

            // check if the player in the Air or not
            if (groundDetector.currentCollisions.Count == 0) _characterController.isAirborne = 1;
            if (groundDetector.currentCollisions.Count > 0) _characterController.isAirborne = 0;
        }

        private void FindAndPauseSounds()
        {
            List<ObjectManager> objectManagers = FindObjectsOfType<ObjectManager>().ToList();
            objectManagers.ForEach(objectManager =>
            {
                if (_soundManagers.Contains(objectManager)) return;
                _soundManagers.Add(objectManager);
            });
            _soundManagers.ForEach(manager =>
            {
                if (!Equals(manager, _musicManager))
                {
                    manager.Pause();
                }
            });
        }

        private void ToggleSneak()
        {
            _characterController.isSneaking = !_characterController.isSneaking;
            if (_characterController.isSneaking)
            {
                playerCameraTransform.position -= new Vector3(0f, 0.5f, 0f);
            }
            else
            {
                playerCameraTransform.position += new Vector3(0f, 0.5f, 0f);
            }
        }

        public void RotateCamera(float rotationY)
        {
            Vector3 cameraRotation = new Vector3(-rotationY, 0, 0);
            if (((playerCameraTransform.eulerAngles +
                  cameraRotation * mouseSensitivity * Time.deltaTime).x >= -90 &&
                 (playerCameraTransform.eulerAngles +
                  cameraRotation * mouseSensitivity * Time.deltaTime).x <= 90) ||
                ((playerCameraTransform.eulerAngles +
                  cameraRotation * mouseSensitivity * Time.deltaTime).x >= 270 &&
                 (playerCameraTransform.eulerAngles +
                  cameraRotation * mouseSensitivity * Time.deltaTime).x <= 450))
            {
                playerCameraTransform.Rotate(
                    cameraRotation * mouseSensitivity * Time.deltaTime, Space.Self);
            }
        }
    }
}