using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    Rigidbody2D rb;
    LineRenderer lineRenderer;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] GameObject planet;
    bool attach = false;
    bool isAttachedtoPlanet = false;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }

   
    void Update()
    {

        GetInputs();
        PlanetParentArranger();
        
    }

    void FixedUpdate() 
    {
       
        MoveUp();
        
    }

    void GetInputs()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            attach = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            attach = false;
        }
        

    }

    void MoveUp()
    {
        if (transform.parent == null)
        {
          
           rb.velocity = transform.up * moveSpeed;
            
        }
    }


    void PlanetParentArranger()
    {
        if (attach)
        {
            lineRenderer.enabled = true;
            LineDrawer();
            if (RightAngleChecker())
            {
                rb.velocity = Vector3.zero;
                transform.SetParent(planet.transform);
                
            }

        }
        else
        {
            lineRenderer.enabled = false;
            transform.SetParent(null);
        }
    }

    void LineDrawer()
    {
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1,planet.transform.position);
    }


    bool  RightAngleChecker()
    {   
        float angle;
        bool result;
        Vector3 vectorA = transform.up;
        Vector3 vectorB = planet.transform.position - transform.position;
        vectorA = vectorA.normalized;
        vectorB = vectorB.normalized;

        angle = Vector2.Angle(vectorA, vectorB);

        
        // DrawLine Code-----
        Vector2 endPointA = transform.position + vectorA;
        Vector2 endPointB = transform.position + vectorB;
        Debug.DrawLine(new Vector3(transform.position.x,transform.position.y,0), new Vector3(endPointA.x,endPointA.y,0), Color.green);
        Debug.DrawLine(new Vector3(transform.position.x,transform.position.y,0), new Vector3(endPointB.x,endPointB.y,0), Color.red);
        

        result = (angle >= 90) ?  true :  false;
        
        return result;

    }

    void DirectionArranger()
    {
        
    }

   

    
    
   
  

    

   
  
    



}
