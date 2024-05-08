using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IProduct, IDamageable
{
    public float health;
    public bool alive = true;

    public virtual void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            alive = false;
        }
}

    public IProduct Clone()
    {
       return Instantiate(this);
    }

    protected virtual void death()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
