using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = 9.81f;
    public float jumpHeight = 3f;
    public float mouseSensitivity = 2f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalVelocity;
    private float rotationX = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        moveDirection.x = move.x * speed;
        moveDirection.z = move.z * speed;

        // Jump logic
        if (controller.isGrounded)
        {
            if (verticalVelocity < 0)
            {
                verticalVelocity = -2f; // Apply small downward force instead of 0 to prevent bouncing
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        // Allow movement in air
        Vector3 airMove = transform.right * moveX + transform.forward * moveZ;
        moveDirection.x = airMove.x * speed;
        moveDirection.z = airMove.z * speed;
        
        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection * Time.deltaTime);

        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        
        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
