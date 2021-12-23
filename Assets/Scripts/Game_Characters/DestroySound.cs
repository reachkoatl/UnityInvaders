using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySound : MonoBehaviour
{
    public float timelife;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timelife);
    }

  
}
