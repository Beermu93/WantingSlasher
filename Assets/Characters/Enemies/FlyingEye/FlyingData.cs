using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/FlyingData")]
public class FlyingData : ScriptableObject
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    public GameObject BulletPrefab => bulletPrefab;
    public float BulletSpeed => bulletSpeed;
}
