using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    Rigidbody2D rd; //Rigidbodyオブジェクト
    float attspeed = 10.0f;  //オブジェクト移動スピード
    private string boxTag = "Box";
    public GameObject player;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();   //Rigidbodyコンポーネント取得
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)|| Input.GetKeyDown(KeyCode.X))
        {//攻撃開始時(Spaceキーを押すと攻撃開始)
            rd.velocity = new Vector2(attspeed, 0); //スピードをつけて攻撃オブジェクトを移動
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == boxTag) {
            Destroy(collision.gameObject);    //攻撃オブジェクトの破棄
        }
       
    }
}
