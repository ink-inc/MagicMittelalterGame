using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Transform body;
    public Transform playerCameraTransform;
    public new Rigidbody rigidbody;
    // public Collider groundDetector;
    public GroundDetector groundDetector;
    public Interactor interactor;

    [Header("Speed values")]
    public float walkingSpeed = 5f;
    public float runningSpeed = 13f;
    public float sprintMultiplier = 1f;
    public float sneakMultiplier = 1f;
    public float jumpPower = 5f;

    [Header("Mouse settings")]
    public float mouseSensitivity = 100f;

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
    }

    private void Update()
    {
        if (!menu.activeSelf) { 
            if (Input.GetButtonDown("Walk/Run"))
                isRunning = !isRunning;
            if (Input.GetButtonDown("Jump"))
                Jump();
            if (Input.GetButtonDown("Interact"))
                interactor.keyDown();
            /* Sprint is removed until we have a concept on how we want to use it ingame
            if (Input.GetButtonDown("Sprint"))
                sprint_Start();
            if (Input.GetButtonUp("Sprint"))
                sprint_End(); */
            if (Input.GetButtonDown("Sneak"))
                toggleSneak();
            if (Input.GetKeyDown("escape"))
            {
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            movement();
            rotation();

            if (groundDetector.currentCollisions.Count == 0) isAirborne = 1;
            if (groundDetector.currentCollisions.Count > 0 ) isAirborne = 0;
        }
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

    private void sprint_Start()
    {
        sprintMultiplier = sprintBoost;
    }

    private void sprint_End()
    {
        sprintMultiplier = 1f;
    }

    private void toggleSneak()
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

    private float clamp(float value, float min, float max)
    {
        if (value <= max)
        {
            if (value >= min)
                return value;
            else
                return min;
        }
        else
            return max;
    }

    private void movement()
    {
        float speed = walkingSpeed;
        if (isRunning)
            speed = runningSpeed;
        speed *= sprintMultiplier;
        speed *= sneakMultiplier;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

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
            velocity *= speed * 2.0f; // TODO: why x2?
            velocity.y = 0;

            rigidbody.AddForce(velocity, ForceMode.Impulse);

            velocity = rigidbody.velocity;
            velocity.y = 0;
            velocity = velocity.normalized * clamp(velocity.magnitude, 0, speed);
            velocity.y = rigidbody.velocity.y;
            rigidbody.velocity = velocity;

        }
    }

    private void rotation()
    {
        // camera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        mouseX = clamp(mouseX, -10, 10);
        mouseY = clamp(mouseY, -10, 10);

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