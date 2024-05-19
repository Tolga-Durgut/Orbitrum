using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBorderAdder : MonoBehaviour
{
    
    void Start()
    {
        ColliderAdd();
    }

    void ColliderAdd()
    {

       // Ekranın köşe noktalarını alır
        Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        Vector2 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.transform.position.z));
        Vector2 bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.transform.position.z));
        Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Ekranın sol tarafında Edge Collider oluşturulur
        GameObject leftCollider = new GameObject("LeftEdgeCollider");
        EdgeCollider2D leftEdgeCollider = leftCollider.AddComponent<EdgeCollider2D>();
        leftEdgeCollider.points = new Vector2[]
        {
            bottomLeft, // Ekranın sol alt köşesi
            topLeft // Ekranın sol üst köşesi
        };

        // Ekranın sağ tarafında Edge Collider oluşturulur
        GameObject rightCollider = new GameObject("RightEdgeCollider");
        EdgeCollider2D rightEdgeCollider = rightCollider.AddComponent<EdgeCollider2D>();
        rightEdgeCollider.points = new Vector2[]
        {
            bottomRight, // Ekranın sağ alt köşesi
            topRight // Ekranın sağ üst köşesi
        };

        // Colliderları Kameranın Child'ı yapar.
        leftCollider.transform.SetParent(Camera.main.transform);
        rightCollider.transform.SetParent(Camera.main.transform);
    }
}
