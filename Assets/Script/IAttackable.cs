using UnityEngine;

public interface IAttackable
{
    void Attack(int dmg, IDamagable target);
}
