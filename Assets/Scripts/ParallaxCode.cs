using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCode : MonoBehaviour
{
    Vector3 lowerLimit;
    

    // Update is called once per frame
    void Update()
    {
        Parallax();
    }


    void Parallax()
    {
        lowerLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));

        if (transform.position.y <= lowerLimit.y)
        {
            
           float difference = lowerLimit.y - transform.position.y;
           Vector3 targetPos =Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.transform.position.z));
           transform.position = new Vector3(transform.position.x, targetPos.y + difference );

        }
    }
}
