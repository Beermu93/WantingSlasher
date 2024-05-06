using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2D = null;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float damage = 0.5f;
    [SerializeField] private float delaySeconds = 1.5f;

    private WaitForSeconds delay = null;

    // Start is called before the first frame update
    void Start()
    {
        delay = new WaitForSeconds(delaySeconds);
        StartCoroutine(missed());

        rb2D.velocity = transform.right * speed;
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
