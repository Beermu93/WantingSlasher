using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Transform golpe;
    [SerializeField] private float radio;
    [SerializeField] private float daño;

    private void golpeS()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(golpe.position, radio);

        foreach (Collider2D obj in objects)
        {
            if (obj.CompareTag("Player"))
            {
                obj.transform.GetComponent<MainChar>().ApplyDamage(daño);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(golpe.position, radio);
    }
}
