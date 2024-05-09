using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : BaseCharacter
{
    [SerializeField] private SoldierData soldierData;

    public string xAxis = "Horizontal";

    private float moveOnX = 0f;
    private bool jump = false;
    [SerializeField] private GameObject shield;

    private void Update()
    {
        GetInputs();

        DoJump();
        DoAnimations();
        float horizontal = UnityEngine.Input.GetAxis(xAxis);
        Movement(horizontal);
    }

    private void FixedUpdate()
    {
        DoRun();
    }

    private void GetInputs()
    {
        moveOnX = UnityEngine.Input.GetAxis(xAxis);
        jump = UnityEngine.Input.GetKeyDown(soldierData.JumpKey);
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, -Vector2.up * groundedFloor, Color.yellow);
    }

        private void DoRun()
    {
        if (moveOnX > 0 && transform.rotation.y != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveOnX < 0 && transform.rotation.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        Rb2D.velocity = new Vector2(moveOnX * speed, Rb2D.velocity.y);
    }

    public void Movement(float horizontal)
    {
        Vector3 movementInput = new Vector2(horizontal, 0f).normalized;
        var movementCommand = new MovementCommand(movementInput, speed, transform, Time.deltaTime);
        EventQueue.Instance.QueueCommand(movementCommand);
    }

    private void DoJump()
    {
        if (jump && CheckGrounded())
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, jumpForce);
        }
    }

    private void DoAnimations()
    {
        Animator.SetBool("Grounded", CheckGrounded());

        if (jump && CheckGrounded() || Rb2D.velocity.y > 1f)
        {
                Animator.SetTrigger("Jump");
        }

        if (Math.Abs(moveOnX) > Mathf.Epsilon && CheckGrounded())
        {
            Animator.SetInteger("AnimState", 1);
        }
        else
        {
            Animator.SetInteger("AnimState", 0);
        }

        if (UnityEngine.Input.GetMouseButtonDown(1))
        {
            Animator.SetTrigger("Block");
            Animator.SetBool("IdleBlock", true);
            shield.SetActive(true);
        }

        else if (UnityEngine.Input.GetMouseButtonUp(1))
        {
            Animator.SetBool("IdleBlock", false);
            shield.SetActive(false);
        }
    }
}
