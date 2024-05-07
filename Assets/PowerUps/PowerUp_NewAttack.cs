using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_NewAttack : PowerUp
{
    [SerializeField] AttackCombo newAttack;
    public override void Activate()
    {
        Soldier.combo.Add(newAttack);
        //Debug.Log("Player recieved " + newAttack);

        base.Activate();
    }
}
