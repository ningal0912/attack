using UnityEngine;

public class Player : CharacterBase
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;

    void Start()
    {
        hp = 100;
        state = CharacterState.Alive;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        void Update()
        {
            if (IsDead) return;

            if (Input.GetMouseButtonDown(0))
            {
                MeleeAttack();
            }

            if (Input.GetMouseButtonDown(1))
            {
                RangeAttack();
            }
        }

        if (IsDead) return;

        Move();

        if (Input.GetMouseButtonDown(0))
        {
            MeleeAttack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            RangeAttack();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * moveSpeed);

        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back * moveSpeed);

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * moveSpeed);

        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    protected override void Die()
    {
        base.Die();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Debug.Log("플레이어 사망: 이동/공격 불가");
    }
}