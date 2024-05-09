using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private KeyCode meleeAttackKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode rangeAttackKey = KeyCode.Mouse1;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    [SerializeField] private float meleeAttackRadius = 0.6f;
    [SerializeField] private float meleeDamage = 2f;
    [SerializeField] private float meleeAttackDelay = 1.1f;
    [SerializeField] private float rangeAttackDelay = 0.3f;

    [SerializeField] private LayerMask enemyLayer;

    public KeyCode MeleeAttackKey => meleeAttackKey;
    public KeyCode RangeAttackKey => rangeAttackKey;
    public KeyCode JumpKey => jumpKey;
    public float MeleeAttackRadius => meleeAttackRadius;
    public float MeleeDamage => meleeDamage;
    public float MeleeAttackDelay => meleeAttackDelay;
    public float RangeAttackDelay => rangeAttackDelay;
    public LayerMask EnemyLayer => enemyLayer;
    
}
