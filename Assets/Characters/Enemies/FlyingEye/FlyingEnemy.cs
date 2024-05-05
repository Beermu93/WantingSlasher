using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour, IDamageable
{
    public float health = 10f;
    public float speed;
    public bool chase = false;
    private bool shoot;
    public bool alive = true;
    private GameObject player;
    public Collider2D chaseCollider;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    [SerializeField] private Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (alive)
        {
            if (chase)
            {
                Chase();
            }
            Flip();
        }
        else
        {
            enemyAnimator.SetBool("Dead", !alive);
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, player.transform.position) <= 3f)
        {
            shoot = true;
            speed = 0;
            enemyAnimator.SetBool("Attack", shoot);
        }
        else
        {
            speed = 3;
            shoot = false;
            enemyAnimator.SetBool("Attack", shoot);
        }
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void shooting()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Vector2 dir = (player.transform.position - transform.position).normalized * bulletSpeed;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x, dir.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chase = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chase = false;
        }
    }
    public virtual void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            alive = false;
        }
    }
    public void death()
    {
        Destroy(gameObject);
    }
}
