using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;

    bool space ;
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        GetInputs();
       

    }

    void FixedUpdate() 
    {
        
        Jump();
        GravityArranger();
        
    }

    void GetInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            space = true;
        }
        

    }

    void Jump()
    {
        if (space && transform.parent != null)
        {
            
            Vector2 target = TargetDirectionArranger();
            rb.AddForce(target * jumpForce  * Time.fixedDeltaTime);
            
            space = false;
        
        }
    }

    
    Vector3 TargetDirectionArranger()
    {
        Vector3 difference = transform.position - transform.parent.position;
        Vector3.Normalize(difference);
        
        
        return difference;
    }
    

    void PlanetAttacher(Collision2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            transform.SetParent(other.transform);
           
        }
    }

    void PlanetDeattacher(Collision2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            transform.SetParent(null);
            
        }
    }
    /// If Player is Connected to a planet this method disables the gravity
    void GravityArranger()
    {
        if (transform.parent == null)
        {
            rb.gravityScale = 1;
        }
        else
        {
            rb.gravityScale = 0;
        }
    }

    void VelocityZero()
    {
        rb.velocity = Vector3.zero;
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        VelocityZero();
        PlanetAttacher(other);

    }

    void OnCollisionExit2D(Collision2D other) 
    {
        PlanetDeattacher(other);
    }



}
