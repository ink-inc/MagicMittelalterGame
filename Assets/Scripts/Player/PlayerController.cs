using System.Collections.Generic;
using System.Linq;
using Interaction;
using Sounds.Manager;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Transform body;

    public Transform playerCameraTransform;
    public new Rigidbody rigidbody;
    public GroundDetector groundDetector;
    public Interactor interactor;
    public PlayerProperties playerProperties;

    [Header("Menu References")]
    public PauseMenu pauseMenu;

    [Header("Mouse settings")]
    public float mouseSensitivity;

    [Header("Player State Attributes")]
    public bool isRunning = false;

    public bool isSneaking = false;
    public float sneakSlow = 0.7f;
    public float isAirborne = 0; // 0: on Ground; 1: on the way back down; 2: just jumped
    public bool isSprinting = false;
    public float sprintBoost = 1.3f;
    
    private CharacterSounds _characterSounds;
    private List<ISoundManager> _soundManagers;
    private MusicManager _musicManager;

    public GameObject dialogueInterface;

    private void Start()
    {
        playerCameraTransform.rotation = Quaternion.identity;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _characterSounds = GetComponent<CharacterSounds>();
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
        if (CloseableMenu.openMenues.Count == 0 && dialogueInterface.activeSelf == false)
        {
            // get all Inputs and calls the methods
            if (Input.GetButtonDown("Walk/Run"))
                isRunning = !isRunning;
            if (Input.GetButtonDown("Jump"))
                Jump();
            if (Input.GetButtonDown("Interact"))
                interactor.KeyDown();
            if (Input.GetButtonDown("Sneak"))
                ToggleSneak();

            Movement();
            Rotation();
        }

        // check if the player in the Air or not
        if (groundDetector.currentCollisions.Count == 0) isAirborne = 1;
        if (groundDetector.currentCollisions.Count > 0) isAirborne = 0;
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

    private void Jump()
    {
        if (groundDetector.currentCollisions.Count != 0)
        {
            Vector3 vel = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
            rigidbody.velocity = vel;
            Vector3 jumpForce = new Vector3(0, playerProperties.jumpPower, 0);
            rigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    private void ToggleSneak()
    {
        isSneaking = !isSneaking;
        if (isSneaking)
        {
            playerCameraTransform.position -= new Vector3(0f, 0.5f, 0f);
        }
        else
        {
            playerCameraTransform.position += new Vector3(0f, 0.5f, 0f);
        }
    }

    private void Movement()
    {
        // TODO: fully convert to StatAttribute
        // get the actual speed with all modificators
        float speed = playerProperties.speed.Value;
        if (isRunning)
            speed *= playerProperties.runMultiplier;
        if(isSneaking)
            speed *= playerProperties.sneakMultiplier;

        // get the inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // makes sure that sideway walking is slower than forward walking
        if (vertical < -0.01) speed *= 0.7f;

        Vector3 velocity = ((transform.forward * vertical) + (transform.right * horizontal));

        // if (CheckMoveableTerrain(playerCameraTransform.position, new Vector3(velocity.x, 0, velocity.z), 5f))
        // {
        // makes sure, that the total veloctity is not higher while walking cross-ways
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
            velocity.y = rigidbody.velocity.y;
            rigidbody.velocity = velocity;
        }
        else
        {
            velocity *= speed;
            velocity.y = 0;

            rigidbody.AddForce(velocity, ForceMode.Impulse);

            // make sure, that the player is not able to be faster then the momentarily speed level is allowing him to be
            velocity = rigidbody.velocity;
            velocity.y = 0;
            velocity = velocity.normalized * Mathf.Clamp(velocity.magnitude, 0, speed);
            velocity.y = rigidbody.velocity.y;

            rigidbody.velocity = velocity;
        }

        if (isRunning && velocity.magnitude > 0.1f && isAirborne == 0)
        {
            _characterSounds.Running(groundDetector.GroundType);
        }
        else if(isSneaking && velocity.magnitude > 0.1f && isAirborne == 0)
        {
            _characterSounds.Sneaking(groundDetector.GroundType);
        }
        //TODO: replace with isWalking flag
        else if (isAirborne == 0 && velocity.magnitude > 0.1f)
        {
            _characterSounds.Walking(groundDetector.GroundType);
        } else
        {
            _characterSounds.StopMovement();
        }
        
        // }
    }

    private void Rotation()
    {
        // get mouse Inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        mouseX = Mathf.Clamp(mouseX, -10, 10);
        mouseY = Mathf.Clamp(mouseY, -10, 10);

        Vector3 bodyRotation = new Vector3(0, mouseX, 0);
        body.Rotate(bodyRotation * mouseSensitivity * Time.deltaTime, Space.Self);

        Vector3 cameraRotation = new Vector3(-mouseY, 0, 0);
        if (((playerCameraTransform.eulerAngles + cameraRotation * mouseSensitivity * Time.deltaTime).x >= -90 &&
            (playerCameraTransform.eulerAngles + cameraRotation * mouseSensitivity * Time.deltaTime).x <= 90) ||
            ((playerCameraTransform.eulerAngles + cameraRotation * mouseSensitivity * Time.deltaTime).x >= 270 &&
            (playerCameraTransform.eulerAngles + cameraRotation * mouseSensitivity * Time.deltaTime).x <= 450))
        {
            playerCameraTransform.Rotate(cameraRotation * mouseSensitivity * Time.deltaTime, Space.Self);
        }
    }

    private bool CheckMoveableTerrain(Vector3 position, Vector3 desiredDirection, float distance)
    {
        Ray slopeRay = new Ray(position, desiredDirection); // cast a Ray from the player in the desired direction
        RaycastHit hit;

        if (Physics.Raycast(slopeRay, out hit, distance))
        {
            if (hit.collider.gameObject) // TODO: maybe change this to "if hits terrain" not just any gameObject
            {
                float slopeAngle = Mathf.Deg2Rad * Vector3.Angle(Vector3.up, hit.normal); // get the angle between the up vector and the object the ray hits

                float radius = Mathf.Abs(0 / Mathf.Sin(slopeAngle));

                if (slopeAngle >= 45f /*change for different angle*/ * Mathf.Deg2Rad)
                {
                    if (hit.distance - (0.5f - playerCameraTransform.position.z) > Mathf.Abs(Mathf.Cos(slopeAngle) * radius) + 0.01) // 0.01 is a threshhold to prevent some bugs
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
        }
        return true;
    }
}