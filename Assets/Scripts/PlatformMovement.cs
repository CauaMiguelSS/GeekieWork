using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class PlatformMovement : MonoBehaviour

{

    private Rigidbody2D _rb;

    private float _horizontal;

    [SerializeField] private float _speed = 5;

    [SerializeField] private float _jumpStrength = 250;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {

        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame

    void Update()

    {

        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))

        {

            _rb.AddForce(new Vector2(0, _jumpStrength));

        }

    }

    private void FixedUpdate()

    {

        _rb.linearVelocity = new Vector2(_horizontal * _speed, _rb.linearVelocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITouchable target))
        {
            target.Active();
        }
    }

}

