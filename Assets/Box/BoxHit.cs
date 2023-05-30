using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHit : MonoBehaviour
{
    private string floorTag = "Floor";
    private string boxTag = "Box";
    public GameObject box;
    BoxCollider2D collider2d;

    Collider2D[] results = new Collider2D[5];


    bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();

    }
    void Update()
    {
        if (!IsHitToEnemy())
        {
            box.transform.Translate(0, -0.01f,0 );
        }
    }
    bool IsHitToEnemy()
    {
        // collider2dと衝突しているcolliderの数が返ってくる
        int hitCount = collider2d.OverlapCollider(new ContactFilter2D(), results);

        if (hitCount > 0)
        {
            for (int i = 0; i < hitCount; i++)
            {
                // 衝突したオブジェクトのTagがEnemyならreturn
                if (results[i].tag == "Floor"|| results[i].tag == "Wall")
                {
                    return true;
                }
            }
        }
        return false;
    }

//private void OnCollisionStay2D(Collision2D floor)
//    {
//        if (floor.collider.tag == floorTag)
//        {
//            isHit = true;
//        }
//    }

//    private void OnCollisionExit2D(Collision2D floor)
//    {        
//            if (floor.collider.tag == floorTag)
//            {
//                isHit = false;
//            }        
//    }
}


