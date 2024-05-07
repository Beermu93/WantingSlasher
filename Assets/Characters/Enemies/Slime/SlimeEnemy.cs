using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 10;
    private float timeNow;
    [SerializeField] private bool alive = true;

    [SerializeField] private GameObject player;
    [SerializeField] private SlimeData slimeData;
    [SerializeField] private Animator enemyAni;
    [SerializeField] private float distance;

    // Start is called before the first frame update
    void Start()
    {
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

        if (distance < slimeData.DistanceBetween)
        {

            timeNow += Time.deltaTime;
            if (timeNow > slimeData.FireRate)
            {
                var bullet = Instantiate(slimeData.BulletPrefab, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * slimeData.BulletSpeed;
                timeNow = 0;
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), slimeData.Speed * Time.deltaTime);
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
