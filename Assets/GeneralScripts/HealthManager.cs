using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private PlayerMovement soldier;

    private void OnEnable()
    {
        if(soldier == null)
        {
            soldier = GetSoldierRef();
        }

        //soldier.OnUpdateHealth += UpdateHealthBar;
    }

    private void OnDisable()
    {
        if (soldier == null)
        {
            soldier = GetSoldierRef();
        }

        //soldier.OnUpdateHealth -= UpdateHealthBar;
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        var fillAmount = currentHealth / maxHealth;
    }
    private PlayerMovement GetSoldierRef()
    {
        return FindObjectOfType<PlayerMovement>();
    }
}
