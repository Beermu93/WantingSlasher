using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class MainChar : BaseCharacter, IDamageable
{
    Interaction interaction;

    public KeyCode meleeAttackKey = KeyCode.Mouse0;
    public KeyCode rangeAttackKey = KeyCode.Mouse1;
    public KeyCode jumpKey = KeyCode.Space;
    public string xAxis = "Horizontal";

    public Transform attackPoint = null;
    public Transform rangeAttackPoint = null;
    public GameObject bullet = null;
    public float meleeAttackRadius = 0.6f;
    public float meleeDamage = 2f;
    public float meleeAttackDelay = 1.1f;
    public float rangeAttackDelay = 0.3f;
    public LayerMask enemyLayer = 8;

    private float moveOnX = 0f;
    private bool jump = false;
    private bool meleeAttack = false;
    private bool rangeAttack = false;
    private float untilMeleeAttackReady = 0;
    private float untilRangeAttackReady = 0;
    private bool isMeleeAttacking = false;

    private void Update()
    {
        GetInputs();

        DoJump();
        DoMeleeAttack();
        DoRangedAttack();
        DoAnimations();

        if (Input.GetMouseButtonDown(0))
        {
            interaction.DoInteraction();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, -Vector2.up * groundedFloor, Color.yellow);
        if (attackPoint != null) 
        {
            Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRadius);
        }
    }

    private void FixedUpdate()
    {
        DoRun();
    }

    private void GetInputs()
    {
        moveOnX = Input.GetAxis(xAxis);
        meleeAttack = Input.GetKeyDown(meleeAttackKey);
        rangeAttack = Input.GetKeyDown(rangeAttackKey);
        jump = Input.GetKeyDown(jumpKey);
    }

    private void DoRun()
    {
        if (moveOnX > 0 && transform.rotation.y == 0 && !isMeleeAttacking)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } 
        else if (moveOnX < 0 && transform.rotation.y != 0 && !isMeleeAttacking)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        Rb2D.velocity = new Vector2(moveOnX * speed, Rb2D.velocity.y);
    }

    private void DoJump()
    {
        if (jump && CheckGrounded())
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, jumpForce);
        }
    }

    private void DoMeleeAttack()
    {
        if (meleeAttack && untilMeleeAttackReady <= 0)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, meleeAttackRadius, enemyLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                IDamageable enemies = colliders[i].GetComponent<IDamageable>();
                if (enemies != null)
                {
                    enemies.ApplyDamage(meleeDamage);
                }
            }

            untilMeleeAttackReady = meleeAttackDelay;
        }
        else
        {
            untilMeleeAttackReady -= Time.deltaTime;
        }
    }

    private void DoRangedAttack()
    {
        if (rangeAttack && untilRangeAttackReady <= 0)
        {
            Debug.Log("asdasd");
            Instantiate(bullet, rangeAttackPoint.position, rangeAttackPoint.rotation);
            untilRangeAttackReady = rangeAttackDelay;
        }
        else
        {
            untilRangeAttackReady -= Time.deltaTime;
        }
    }

    private void DoAnimations()
    {
        Animator.SetBool("Grounded", CheckGrounded());

        if(meleeAttack)
        {
            if(!isMeleeAttacking)
            {
                StartCoroutine(MeleeAttackAnimDelay());
            }
        }

        if (rangeAttack)
        {
            Animator.SetTrigger("Shoot");
        }

        if (jump && CheckGrounded() || Rb2D.velocity.y > 1f)
        {
            if(!isMeleeAttacking)
            {
                Animator.SetTrigger("Jump");
            }     
        }

        if(Math.Abs(moveOnX) > 0.1f && CheckGrounded())
        {
            Animator.SetInteger("AnimState", 2);
        } 
        else
        {
            Animator.SetInteger("AnimState", 0);
        }
    }

    private IEnumerator MeleeAttackAnimDelay()
    {
        Animator.SetTrigger("Attack");
        isMeleeAttacking = true;
        yield return new WaitForSeconds(meleeAttackDelay);
        isMeleeAttacking = false;
    }
    public virtual void ApplyDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
}
