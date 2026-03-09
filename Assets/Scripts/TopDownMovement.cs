using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    private Vector2 movement;
    private Vector2 lastDirection;

    [SerializeField] private float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Captura do input
        movement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        // Atualiza última direção apenas se estiver se movendo
        if (movement != Vector2.zero)
        {
            lastDirection = movement;
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        HandleAnimationDirection();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    void HandleAnimationDirection()
    {
        // Usa a direção atual se estiver andando,
        // senão usa a última direção salva
        Vector2 direction = movement != Vector2.zero ? movement : lastDirection;

        ResetLayer();

        // Direita / Esquerda
        if (direction.x != 0)
        {
            anim.SetLayerWeight(2, 1);

            if (direction.x > 0)
                sprite.flipX = false;
            else
                sprite.flipX = true;
        }
        // Cima
        else if (direction.y > 0)
        {
            anim.SetLayerWeight(1, 1);
        }
        // Baixo
        else if (direction.y < 0)
        {
            anim.SetLayerWeight(0, 1);
        }
    }

    void ResetLayer()
    {
        anim.SetLayerWeight(0, 0); // Down
        anim.SetLayerWeight(1, 0); // Up
        anim.SetLayerWeight(2, 0); // Right
    }
}