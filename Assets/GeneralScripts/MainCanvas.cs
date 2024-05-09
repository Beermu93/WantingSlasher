using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    public HealthManager HealthManager => healthManager;

    [SerializeField] private HealthManager healthManager;
}
