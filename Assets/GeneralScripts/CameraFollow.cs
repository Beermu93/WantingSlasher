using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject mainCharacter;

    void Update()
    {
        if (mainCharacter != null)
        {
            Vector3 position = transform.position;
            position.x = mainCharacter.transform.position.x;
            transform.position = position;
        }
    }
}
