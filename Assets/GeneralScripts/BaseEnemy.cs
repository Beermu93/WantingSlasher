using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IProduct
{
    public IProduct Clone()
    {
       return Instantiate(this);
    }

    protected virtual void death()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
