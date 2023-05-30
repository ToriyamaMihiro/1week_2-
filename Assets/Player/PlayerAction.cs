using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    //public GameObject box;
    public BoxCollider2D col;

    Rigidbody2D rigidbody2D;

    private string boxTag = "Box";
    private string floorTag = "Floor";
    private string goalTag = "Goal";

    /*---- 変数宣言 ----*/
    public float moveSpeed = 0.005f;
    public float jumpPower = 80.0f;
    public float Power = 3.0f;

    float xLimit = 26.0f;
    float yLimit = 18.0f;
    bool isRight = false;
    bool isLeft = true;
    bool isHit = false;
    bool isJump = false;
    private Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        /*---- 初期化 ----*/
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*---- キー移動 ----*/
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            isRight = false;
            isLeft = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            isRight = true;
            isLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);

        }
        /*---- 移動制限 ----*/
        Vector3 player_pos = transform.position;
        player_pos.x = Mathf.Clamp(player_pos.x, -xLimit, xLimit);
        player_pos.y = Mathf.Clamp(player_pos.y, -yLimit, yLimit);
        transform.position = new Vector2(player_pos.x, player_pos.y);

        /*---- 移動制限 ----*/
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }
    /*---- ジャンプ ----*/
    //トリガーと他のオブジェクトが接触
    //床との接触


    //トリガーと他のオブジェクトが離れた
    private void OnCollisionExit2D(Collision2D floor)
    {

        if (floor.collider.tag == floorTag)
        {
            isJump = false;
        }
        else if (floor.collider.tag == boxTag)
        {
            isJump = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == floorTag)
        {
            isJump = true;
        }

        if (collision.collider.tag == boxTag)
        {
            isJump = true;
            //ボックスの移動
            if (Input.GetKey(KeyCode.Z))
            {
                if (Power >= 1)
                {
                    if (isLeft)
                    {
                        collision.transform.Translate(-2, 0, 0);
                    }
                    else if (isRight)
                    {
                        collision.transform.Translate(2, 0, 0);
                    }
                }
                Power -= 1;
            }
            //ボックスの破壊
            if (Input.GetKey(KeyCode.X))
            {
                if (Power >= 2)
                {
                    Destroy(collision.gameObject);
                    Power -= 2;
                }
            }
        }
    }
}
