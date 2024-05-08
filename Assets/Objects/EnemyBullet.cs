using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb2D = null;
    [SerializeField] private float life = 3;
    [SerializeField] private float damage = 0.5f;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.ApplyDamage(damage);
            }

            gameObject.SetActive(false);
            Destroy(gameObject);
        } else if(collision.gameObject.layer == 11)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
