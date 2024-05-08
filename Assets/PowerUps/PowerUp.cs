using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerMovement soldier = null;
    private SoldierCombat combo = null;

    public PlayerMovement Soldier => soldier;
    public SoldierCombat Combo => combo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerMovement>())
            {
                soldier = collision.GetComponent<PlayerMovement>();
            }
            if (collision.GetComponent<SoldierCombat>())
            {
                combo = collision.GetComponent<SoldierCombat>();
            }
            Activate();
        }
    }

    public virtual void Activate()
    {
        Destroy(gameObject);
    }
}
