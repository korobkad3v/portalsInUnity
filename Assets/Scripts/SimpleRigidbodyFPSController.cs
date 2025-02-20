using UnityEngine;

public class SimpleRigidbodyFPSController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float mouseSensitivity = 2.0f;

    private Rigidbody rb;
    private Camera playerCamera;
    private float verticalRotation = 0;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void Update()
    {
        // Rotation
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Movement
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed;
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
        movement = transform.rotation * movement;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}