using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactRadius;
    [SerializeField] private LayerMask interactMask;

    public void DoInteraction()
    {
        Debug.Log(message: "toque la E");

        Collider2D[] interactbles = Physics2D.OverlapCircleAll(interactionPoint.position, interactRadius, interactMask);

        foreach (Collider2D interactble in interactbles)
        {
            VerticalDoor door = interactble.GetComponent<VerticalDoor>();
            if (door != null)
            {
                door.DoorInteraction();
            }
        }
    }
}
