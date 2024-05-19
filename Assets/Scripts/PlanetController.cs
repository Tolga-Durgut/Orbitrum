using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    
    void Update()
    {
        PlanetRotater();
    }

    //Rotates The Planet 
    void PlanetRotater()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }

    
}
