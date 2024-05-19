using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0f,0f,-10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    private Vector3 smoothedPos;

    bool isPlayerTarget;
    bool isPlanetTarget;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject player;
    
    void Update()
    {
        
        
        TargetArranger();
        
    }


    void LateUpdate() 
    {
        smoothedPos = Vector3.SmoothDamp(transform.position,target.position + offset, ref velocity , smoothTime);

        transform.position = new Vector3(transform.position.x , smoothedPos.y , transform.position.z);
        
    }

    // with the help of flags it only arranges the target once for each jump
    void TargetArranger()
    {

        if (player.transform.parent != null)
        {
            if (!isPlanetTarget)
            {
                
                target = player.transform.parent;
                
                isPlayerTarget = false;
                isPlanetTarget = true;
            }
        }
        else
        {
            if (!isPlayerTarget)
            {
                
                target = player.transform;

                isPlayerTarget = true;
                isPlanetTarget = false;
                
                
            }
        }
        
    }
    

    
}
