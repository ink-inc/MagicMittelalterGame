using System.Collections.Generic;
using System.Linq;
using Interaction;
using Sounds.Manager;
using UnityEngine;

namespace Character.Player
{
    public class PlayerController : CharacterController
    {
        private MusicManager _musicManager;
        private List<ISoundManager> _soundManagers;

        public GameObject dialogueInterface;
        public Interactor interactor;

        public Inventory inventory;


        [Header("Mouse settings")] public float mouseSensitivity;

        [Header("Menu References")] public PauseMenu pauseMenu;
        public Transform playerCameraTransform;
        public PlayerProperties playerProperties;
        public QuestjournalDisplay questDisplay;

        private void Start()
        {
            base.Start();

            playerCameraTransform = Camera.main.transform;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _musicManager = GetComponent<MusicManager>();

            _soundManagers = FindObjectsOfType<MonoBehaviour>().OfType<ISoundManager>().ToList();
        }

        protected override void Update()
        {
            base.Update();

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

            if (Input.GetKeyDown(KeyCode.J))
                questDisplay.Toggle();

            if (CloseableMenu.openMenues.Count != 0 || dialogueInterface.activeSelf)
                return;
            
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (Cursor.visible)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            }

            // get all Inputs and calls the methods
            if (Input.GetButtonDown("Walk/Run"))
                isRunning = !isRunning;
            if (Input.GetButtonDown("Jump"))
                Jump(playerProperties.jumpPower);
            if (Input.GetButtonDown("Interact"))
                interactor.KeyDown();
            if (Input.GetButtonDown("Sneak"))
                ToggleSneak();

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Movement(horizontal, vertical, playerProperties);

            float rotationX = Input.GetAxis("Mouse X");
            Rotation(rotationX, mouseSensitivity);

            float rotationY = Input.GetAxis("Mouse Y");
            RotateCamera(rotationY);
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
            if (isSneaking)
            {
                isSneaking = false;
                playerCameraTransform.position -= new Vector3(0f, 0.5f, 0f);
            }
            else
            {
                isSneaking = true;
                playerCameraTransform.position += new Vector3(0f, 0.5f, 0f);
            }
        }

        private void RotateCamera(float rotationY)
        {
            Vector3 cameraRotation = new Vector3(-rotationY, 0, 0) * (mouseSensitivity * Time.deltaTime);
            float x = (playerCameraTransform.eulerAngles + cameraRotation).x;
            if (x >= -90 && x <= 90 || x >= 270 && x <= 450)
            {
                playerCameraTransform.Rotate(cameraRotation, Space.Self);
            }
        }
    }
}