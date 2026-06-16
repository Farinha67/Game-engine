using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    public float crouchSpeed = 2.5f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    public float standHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeedMultiplier = 0.5f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isCrouching;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.height = standHeight;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKeyDown(KeyCode.LeftControl))
            isCrouching = true;

        if (Input.GetKeyUp(KeyCode.LeftControl))
            isCrouching = false;

        HandleCrouch();

        float speed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
            speed = runSpeed;

        if (isCrouching)
            speed *= crouchSpeedMultiplier;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouching)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleCrouch()
    {
        if (isCrouching)
            controller.height = crouchHeight;
        else
            controller.height = standHeight;
    }
}