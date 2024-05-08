using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : BaseEnemy
{
    private float timeNow;
    [SerializeField] private GameObject player;
    [SerializeField] private SlimeData slimeData;
    [SerializeField] private Animator enemyAni;
    [SerializeField] private float distance;

    // Start is called before the first frame update
    void Start()
    {
        health = 10f;
        enemyAni = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
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
}
