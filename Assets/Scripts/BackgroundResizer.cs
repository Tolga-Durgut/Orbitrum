using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundResizer : MonoBehaviour
{
    void Start()
    {
        
        transform.position= new Vector3 (Camera.main.transform.position.x,Camera.main.transform.position.y,transform.position.z);
        Resize();
        transform.SetParent(Camera.main.transform);
    }
    void Resize ()
    {
        SpriteRenderer sr=GetComponent<SpriteRenderer>();
        if(sr==null) return;
        
        transform.localScale=new Vector3(1,1,1);
        
        float width=sr.sprite.bounds.size.x;
        float height=sr.sprite.bounds.size.y;
        
        float worldScreenHeight=Camera.main.orthographicSize*2f;
        float worldScreenWidth=worldScreenHeight/Screen.height*Screen.width;
        
        Vector3 xWidth = transform.localScale;
        xWidth.x=worldScreenWidth / width;
        transform.localScale=xWidth;
        //transform.localScale.x = worldScreenWidth / width;
        Vector3 yHeight = transform.localScale;
        yHeight.y=worldScreenHeight / height;
        transform.localScale=yHeight;
        //transform.localScale.y = worldScreenHeight / height; 
    }
}
