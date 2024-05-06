using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : MonoBehaviour, IDamageable
{
    public float health = 100;
    public float speed;
    public bool chase = false;
    private bool attack;
    public bool alive = true;

    private GameObject player;
    public Collider2D chaseCollider;

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
                enemyAnimator.SetBool("Chasing", chase);
            }
            else
            {
                enemyAnimator.SetBool("Chasing", chase);
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
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, player.transform.position) <= 3f)
        {
            attack = true;
            speed = 0;
            enemyAnimator.SetBool("Attack", attack);
        }
        else
        {
            speed = 3;
            attack = false;
            enemyAnimator.SetBool("Attack", attack);
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
    public void ApplyDamage(float damage)
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
