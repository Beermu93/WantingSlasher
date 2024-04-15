using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PowerUp_Heal : PowerUp
{
    public float amount = 5f;

    public override void Activate()
    {
        Player.CurrentHealth += amount;
        Debug.Log("Player: " + Player.CurrentHealth);

        base.Activate();
    }
}
