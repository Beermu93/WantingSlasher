using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : BaseEnemy
{
    [SerializeField] private bool chase = false;
    private bool shoot;
    [SerializeField] private GameObject player;
    [SerializeField] private Collider2D chaseCollider;
    [SerializeField] private float speed;

    [SerializeField] private FlyingData flygingData;
    [SerializeField] private Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        health = 10f;
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
        var bullet = Instantiate(flygingData.BulletPrefab, transform.position, transform.rotation);
        Vector2 dir = (player.transform.position - transform.position).normalized * flygingData.BulletSpeed;
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
}
