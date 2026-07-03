using UnityEngine;

public class Enemy : CharacterBase
{
    public Transform player;
    public float moveSpeed = 3f;

    private Renderer[] renderers;
    private Collider[] colliders;
    private Rigidbody rb;

    void Start()
    {
        hp = 5;
        state = CharacterState.Alive;

        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (IsDead) return;
        if (player == null) return;

        Vector3 dir = player.position - transform.position;
        dir.y = 0;

        transform.position += dir.normalized * moveSpeed * Time.deltaTime;
    }

    protected override void Die()
    {
        base.Die();

        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }

        foreach (Collider c in colliders)
        {
            c.enabled = false;
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        Debug.Log("적 사망: 숨김 처리");
    }
}