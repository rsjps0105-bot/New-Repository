using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float gravity = -30f;
    [SerializeField] float stickToGroundForce = -10f;
    [SerializeField] float deathY = -10f;

    CharacterController controller;
    public Health health;
    float yVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Vector3 move = Vector3.right * h * speed;

        // èdóÕèàóù
        if (controller.isGrounded)
        {
            yVelocity = stickToGroundForce;
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }

        move.y = yVelocity;

        controller.Move(move * Time.deltaTime);

        // óéâ∫éÄ
        if (transform.position.y < deathY)
        {
            health.TakeDamage(int.MaxValue, DamageSource.Environment);
        }
    }
}
