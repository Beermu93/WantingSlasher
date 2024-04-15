using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalDoor : MonoBehaviour
{
    private const string OPEN = "Open";
    [SerializeField] private Animator animator;
    private bool isOpen;
    private static readonly int Open = Animator.StringToHash(OPEN);

    public void DoorInteraction()
    {
        isOpen = !isOpen;
        animator.SetBool(OPEN, isOpen);
    }

}
