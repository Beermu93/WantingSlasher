using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public float health = 10f;

    public float speed = 5f;
    public float jumpForce = 5f;
    public float groundedFloor = 5f;

    private Rigidbody2D rb2D = null;
    private Animator animator = null;
    private float currentHealth = 1f;

    public Rigidbody2D Rb2D
    {
        get { return rb2D; }
        protected set { rb2D = value; }
    }
    public Animator Animator
    {
        get { return animator; }
        protected set { animator = value; }
    }
    public float CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (GetComponent<Rigidbody2D>())
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        if (GetComponent<Animator>())
        {
            animator = GetComponent<Animator>();
        }

        currentHealth = health;
    }

    protected bool CheckGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, groundedFloor);
    }
    protected virtual void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
