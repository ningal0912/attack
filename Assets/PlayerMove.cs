using UnityEngine;

public class PlayerMove : Character
{
    public float jumpForce = 5f;

    private Rigidbody rb;

    void Start()
    {
        hp = 100;
        moveSpeed = 5f;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * moveSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();

        if (enemy != null)
        {
            Damage(5);
            enemy.Damage(5);
        }
    }
}