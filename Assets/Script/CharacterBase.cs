using UnityEngine;

public enum CharacterState
{
    Alive,
    Dead
}

public class CharacterBase : MonoBehaviour, IDamagable, IAttackable
{
    public int hp = 100;
    public CharacterState state = CharacterState.Alive;

    public bool IsDead
    {
        get { return state == CharacterState.Dead; }
    }

    public virtual void Damage(int dmg)
    {
        if (IsDead) return;

        hp -= dmg;

        if (hp <= 0)
        {
            hp = 0;
            Die();
        }
    }

    public virtual void Attack(int dmg, IDamagable target)
    {
        if (IsDead) return;
        if (target == null) return;

        target.Damage(dmg);
    }

    public virtual void RangeAttack()
    {
        if (IsDead) return;

        IDamagable target;

        if (Raycasting.GetTargetByLine(transform.position, transform.forward, out target))
        {
            Attack(10, target);
        }
    }

    public virtual void MeleeAttack()
    {
        if (IsDead) return;

        IDamagable target;

        if (OverlapSphereAttack.GetTarget(transform.position, 2f, out target))
        {
            Attack(10, target);
        }
    }

    protected virtual void Die()
    {
        state = CharacterState.Dead;
    }
}