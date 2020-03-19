using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Transform body;
    public Transform playerCameraTransform;
    public new Rigidbody rigidbody;
    public GroundDetector groundDetector;
    public Interactor interactor;

    [Header("Speed values")]
    public float walkingSpeed;
    public float runningSpeed;
    public float sneakMultiplier;
    public float jumpPower;

    [Header("Mouse settings")]
    public float mouseSensitivity;

    [Header("Player State Attributes")]
    public bool isRunning = false;
    public bool isSneaking = false;
    public float sneakSlow = 0.7f;
    public float isAirborne = 0; // 0: on Ground; 1: on the way back down; 2: just jumped
    public bool isSprinting = false;
    public float sprintBoost = 1.3f;

    public GameObject menu;


    private void Start()
    {
        playerCameraTransform.rotation = Quaternion.identity;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // if the menu is active, there should be no movement
        if (!menu.activeSelf) { 
            // get all Inputs and calls the methods
            if (Input.GetButtonDown("Walk/Run"))
                isRunning = !isRunning;
            if (Input.GetButtonDown("Jump"))
                Jump();
            if (Input.GetButtonDown("Interact"))
                interactor.keyDown();
            if (Input.GetButtonDown("Sneak"))
                ToggleSneak();
            if (Input.GetKeyDown("escape"))
            {
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            Movement();
            Rotation();
        }

        // check if the player in the Air or not 
        if (groundDetector.currentCollisions.Count == 0) isAirborne = 1;
        if (groundDetector.currentCollisions.Count > 0) isAirborne = 0;
    }

    private void Jump()
    {
        if (groundDetector.currentCollisions.Count != 0)
        {
            Vector3 vel = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
            rigidbody.velocity = vel;
            Vector3 jumpForce = new Vector3(0, jumpPower, 0);
            rigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }

    }

    private void ToggleSneak()
    {
        isSneaking = !isSneaking;
        if (isSneaking)
        {
            sneakMultiplier = 0.7f;
            playerCameraTransform.position -= new Vector3(0f, 0.1f, 0f);
        } else {
            sneakMultiplier = 1.0f;
            playerCameraTransform.position += new Vector3(0f, 0.1f, 0f);
        }
    }

    private void Movement()
    {
        // get the actual speed with all modificators
        float speed = walkingSpeed;
        if (isRunning)
            speed = runningSpeed;
        speed *= sneakMultiplier;

        // get the inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // makes sure that sideway walking is slower than forward walking
        if (vertical < -0.01) speed *= 0.7f;

        // makes sure, that the total veloctity is not higher while walking cross-ways
        Vector3 velocity = ((transform.forward * vertical) + (transform.right * horizontal));
        if (velocity.magnitude > 1.01)
        {
            velocity = velocity.normalized;
        }
        
        // manages movement depending on being airborne or not
        if (isAirborne == 0)
        {
            velocity *= speed;
            velocity.y = rigidbody.velocity.y;
            rigidbody.velocity = velocity;
        } else
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
}