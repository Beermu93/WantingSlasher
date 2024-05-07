using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/SlimeData")]
public class SlimeData : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 7f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float distanceBetween;

    public float Speed => speed;
    public GameObject BulletPrefab => bulletPrefab;
    public float BulletSpeed => bulletSpeed;
    public float FireRate => fireRate;
    public float DistanceBetween => distanceBetween;

}
