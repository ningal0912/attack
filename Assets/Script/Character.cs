using UnityEngine;

public class Character : MonoBehaviour
{
    public int hp;
    public float moveSpeed;

    public void Damage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}