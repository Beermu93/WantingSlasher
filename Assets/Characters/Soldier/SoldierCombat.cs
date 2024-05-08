using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class SoldierCombat : MonoBehaviour
{
    public List<AttackCombo> combo;
    float lastClickedTime;
    float lastComboEnd;
    int comboIndex;

    Animator comboAnim;

    // Start is called before the first frame update
    void Start()
    {
        comboAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        ExitAttack();
    }

    void Attack()
    {
        float comboDelay = 0.6f;
        float attackDelay = 0.4f;

        if (Time.time - lastComboEnd > comboDelay && comboIndex <= combo.Count)
        {
            CancelInvoke("EndCombo");

            if (Time.time - lastClickedTime > attackDelay)
            {
                comboAnim.runtimeAnimatorController = combo[comboIndex].animatorOV;
                comboAnim.Play("ComboAttack", 0, 0);

                comboIndex++;
                lastClickedTime = Time.time;

                if (comboIndex >= combo.Count)
                {
                    comboIndex = 0;
                }
            }
        }
    }

    void ExitAttack()
    {
        if (comboAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && comboAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            Invoke("EndCombo", 1);
        }
    }

    void EndCombo()
    {
        comboIndex = 0;
        lastComboEnd = Time.time;
    }

    [SerializeField] private Transform golpe;
    [SerializeField] private float radio;

    private void Hit()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(golpe.position, radio);

        foreach (Collider2D obj in objects)
        {
            if (obj.CompareTag("Enemy"))
            {
                obj.transform.GetComponent<IDamageable>().ApplyDamage(combo[2].damage);
                //obj.transform.GetComponent<FlyingEnemy>().ApplyDamage(combo[2].damage);
                //obj.transform.GetComponent<SlimeEnemy>().ApplyDamage(combo[2].damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(golpe.position, radio);
    }
}
