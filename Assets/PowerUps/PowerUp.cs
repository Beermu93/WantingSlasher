using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private MainChar player = null;

    public MainChar Player
    {
        get { return player; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.GetComponent<MainChar>())
            {
                player = collision.GetComponent<MainChar>();
            }
            Activate();
        }
    }

    public virtual void Activate()
    {
        Destroy(gameObject);
    }
}
