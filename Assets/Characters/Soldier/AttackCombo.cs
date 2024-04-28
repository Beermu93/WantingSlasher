using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attacks/NormalAttack")]
public class AttackCombo : ScriptableObject
{
    public AnimatorOverrideController animatorOV;
    public float damage;
}
