using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter, IDamageable
{
    public virtual void ApplyDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
}
