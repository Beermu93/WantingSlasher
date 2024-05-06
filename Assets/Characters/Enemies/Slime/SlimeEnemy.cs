using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float health = 100;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float fireRate = 0.5f;
    private float timeNow;
    [SerializeField] private bool alive = true;
    private Animator enemyAni;

    [SerializeField] private GameObject player;
    [SerializeField] private float distanceBetween;
    [SerializeField] private float distance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemyAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            ShootPlayer();
        }
        else
        {
            enemyAni.SetBool("Dead", !alive);
        }
    }

    public void ShootPlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween)
        {

            timeNow += Time.deltaTime;
            if (timeNow > fireRate)
            {
                var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
                timeNow = 0;
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
            if (player.transform.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
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
