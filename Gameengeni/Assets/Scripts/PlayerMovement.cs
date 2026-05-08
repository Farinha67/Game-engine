using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    public float jumpHeight = 1.5f;

    [Header("Gravidade")]
    public float gravity = -9.81f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Verifica chão
        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundDistance,
            groundMask
        );

        // Mantém no chão
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Direção
        Vector3 move = transform.right * x + transform.forward * z;

        // Correr
        float speed = Input.GetKey(KeyCode.LeftShift)
            ? runSpeed
            : walkSpeed;

        controller.Move(move * speed * Time.deltaTime);

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravidade
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}