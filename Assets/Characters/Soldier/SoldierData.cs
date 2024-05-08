using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSoldierData", menuName = "Data/SoldierData")]
public class SoldierData : ScriptableObject
{
    [SerializeField] private KeyCode shieldKey = KeyCode.Mouse1;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    [SerializeField] private LayerMask enemyLayer;

    public KeyCode ShieldKey => shieldKey;
    public KeyCode JumpKey => jumpKey;
    public LayerMask EnemyLayer => enemyLayer;

}
