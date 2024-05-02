using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/FlyingData")]

public class FlyingData : ScriptableObject
{
    //[SerializeField] private float health = 100;
    //[SerializeField] private float speed;
    //[SerializeField] private GameObject player;
    //[SerializeField] private Collider2D chaseCollider;
    [SerializeField] private float bulletSpeed = 8f;

    //public float Health => health;
    //public float Speed => speed;
    //public GameObject Player => player;
    //public Collider2D ChaseCollider => chaseCollider;
    public float BulletSpeed => bulletSpeed;

}
