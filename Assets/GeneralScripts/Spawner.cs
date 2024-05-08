using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private SkeletonEnemy skeleton;
    private GameObject skeletonEnemy;

    private FlyingEnemy flyingEye;
    private GameObject flyingEnemy;

    private SlimeEnemy slime;
    private GameObject slimeEnemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            skeleton.Clone();
        }
    }
}
