using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter, IDamageable
{
    [SerializeField] private EnemyData enemyData;
}
