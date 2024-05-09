using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Controller : MonoBehaviour
{
    public Animator knightAnim;
    public bool isAttacking = false;
    public static Knight_Controller instance;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        knightAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DoAttack();
    }

    private void DoAttack()
    {
        if (Input.GetButton("Fire1") && !isAttacking)
        {
            isAttacking = true;
        }
    }
}
