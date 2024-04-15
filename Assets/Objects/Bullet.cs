using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2D = null;
    public float speed = 15f;
    public float damage = 0.5f;
    public float delaySeconds = 1.5f;

    private WaitForSeconds delay = null;

    // Start is called before the first frame update
    void Start()
    {
        delay = new WaitForSeconds(delaySeconds);
        StartCoroutine(missed());

        rb2D.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 8)
        {
            IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.ApplyDamage(damage);
            }

            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private IEnumerator missed()
    {
        yield return delay;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
