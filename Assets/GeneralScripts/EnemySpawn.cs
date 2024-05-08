using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Spawner spawner;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform spawnLocation;

     void Awake()
    {
        spawner = new Spawner();
        spawner.SetSpawn(enemy);
    }

    private void Start()
    {
        spawner.CreateEnemy(Spawner.EnemyType.Easy, spawnLocation);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Player"))
    //    {
    //        spawner.CreateEnemy(Spawner.EnemyType.Easy, spawnLocation);
    //    }
    //}
}
