using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryShip : MonoBehaviour
{
    public float speendship = 5.0f;
    private Vector3 _direction = Vector2.right;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += _direction * this.speendship * Time.deltaTime;
        foreach (Transform invader in this.transform)
        {
            print("hola");
        }

        

       
    }
}
