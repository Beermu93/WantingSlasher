using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private MainChar player = null;
    private SoldierCombat soldier = null;

    public MainChar Player => player;
    public SoldierCombat Soldier => soldier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.GetComponent<MainChar>())
            {
                player = collision.GetComponent<MainChar>();
            }
            if (collision.GetComponent<SoldierCombat>())
            {
                soldier = collision.GetComponent<SoldierCombat>();
            }
            Activate();
        }
    }

    public virtual void Activate()
    {
        Destroy(gameObject);
    }
}
