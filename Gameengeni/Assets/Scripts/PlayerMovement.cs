using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    public float crouchSpeed = 2.5f;
    public float jumpHeight = 4f;

    [Header("Gravidade")]
    public float gravity = -9.81f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Crouch")]
    public float standHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeedMultiplier = 0.5f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isCrouching;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        controller.height = standHeight;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // CHECAR CHÃO
        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundDistance,
            groundMask
        );

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // INPUT MOVIMENTO
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // AGACHAR
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
        }

        HandleCrouch();

        // VELOCIDADE
        float speed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            speed = runSpeed;
        }

        if (isCrouching)
        {
            speed *= crouchSpeedMultiplier;
        }

        controller.Move(move * speed * Time.deltaTime);

        // PULO
        if (Input.GetButtonDown("Jump") && isGrounded && !isCrouching)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // GRAVIDADE
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void HandleCrouch()
    {
        if (isCrouching)
        {
            controller.height = crouchHeight;
        }
        else
        {
            controller.height = standHeight;
        }
    }
}