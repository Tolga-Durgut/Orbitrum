using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float wallJumpForce = 10;

    bool space ;
    bool canWallSlide;
    bool isWallSliding;
    bool isWallDetected;

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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            space = false;
        }
        

    }

    
   
    void Jump()
    {
        if (space && transform.parent != null)
        {
            Vector2 target = TargetDirectionArranger();
            PlanetDeattacher();
            rb.AddForce(target * jumpForce  * Time.fixedDeltaTime);
            
            space = false;
        
        }
        else if (space && isWallDetected)
        {   
            VelocityZero();
            WallJump();
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

    void PlanetDeattacher()
    {
        
        transform.SetParent(null);
            
        
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
   

   #region  WallSlide and WallJump
    void WallEntryCheck(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            isWallDetected = true;
            
        }
        
    }

    void WallExitCheck(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            isWallDetected = false;
            
        }
    }

    void WallSlide()
    {
        if (isWallDetected && rb.velocity.y < 0 && canWallSlide)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    void WallJump()
    {
        if (transform.position.x < 0)
            {
                rb.AddForce(Vector2.one * wallJumpForce * Time.fixedDeltaTime );
            }
            else if (transform.position.x > 0)
            {
                rb.AddForce(new Vector2(-1,1) * wallJumpForce * Time.fixedDeltaTime );
            }
    }
    #endregion
    void OnCollisionEnter2D(Collision2D other) 
    {
        VelocityZero();
        PlanetAttacher(other);
        WallEntryCheck(other);

    }
   
    void OnCollisionExit2D(Collision2D other) 
    {
        WallExitCheck(other); ;
    }



}
