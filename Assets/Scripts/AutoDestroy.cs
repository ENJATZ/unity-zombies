using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public int destroyAfter;
    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }
}
