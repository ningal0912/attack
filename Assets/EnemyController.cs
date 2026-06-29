using UnityEngine;

public class EnemyController : Character
{
    public Transform player;

    void Start()
    {
        hp = 5;
        moveSpeed = 3f;
    }

    void Update()
    {
        if (player == null)
        {
            Debug.Log("Enemy의 player가 비어있음");
            return;
        }

        Vector3 dir = player.position - transform.position;
        dir.y = 0;

        transform.position += dir.normalized * moveSpeed * Time.deltaTime;
    }
}