using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject slime;
    [SerializeField] private GameObject eye;
    [SerializeField] private GameObject skeleton;
    [SerializeField] private GameObject finalBoss;

    public enum EnemyType
    {
        Easy = 0,
        Medium = 1,
        Hard = 2,
        Boss = 3,
    }
    public BaseEnemy CreateEnemy(EnemyType type, Transform pos)
    {
        switch (type)
        {
            case EnemyType.Easy:
                GameObject Slime = Instantiate(slime, pos);
                return Slime.GetComponent<BaseEnemy>();

            case EnemyType.Medium:
                GameObject Eye = Instantiate(eye, pos);
                return Eye.GetComponent<BaseEnemy>();

            case EnemyType.Hard:
                GameObject Skeleton = Instantiate(skeleton, pos);
                return Skeleton.GetComponent<BaseEnemy>();

            case EnemyType.Boss:
                GameObject FinalBoss = Instantiate(finalBoss, pos);
                return FinalBoss.GetComponent<BaseEnemy>();

            default:
                Debug.LogError("Enemy type unknown: " + type);
                return null;
        }
    }

    public void SetSpawn(GameObject enemy)
    {
        slime = enemy;
        eye = enemy;
        skeleton = enemy;
        finalBoss = enemy;
    }
}
