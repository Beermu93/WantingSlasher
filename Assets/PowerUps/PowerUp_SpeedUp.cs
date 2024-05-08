using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_SpeedUp : PowerUp
{
    public float amount = 1.5f;

    public override void Activate()
    {
        Soldier.speed += amount;
        Debug.Log("You now have " + Soldier.speed + " speed");

        base.Activate();
    }
}
