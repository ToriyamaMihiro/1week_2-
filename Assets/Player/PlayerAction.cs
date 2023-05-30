using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    //public GameObject box;
    public GameObject particlePrefab;

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
    int particleTime = 0;
    int particleCoolTime = 10;
    private Rigidbody2D rb = null;


    // Start is called before the first frame update
    void Start()
    {
        /*---- 初期化 ----*/
        Application.targetFrameRate = 60;//frameレートの固定
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        particleTime++;
        /*---- キー移動 ----*/
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            if (particleTime % particleCoolTime == 0)
            {

            }
            isRight = false;
            isLeft = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            if (particleTime % particleCoolTime == 0)
            {

            }
            isRight = true;
            isLeft = false;
        }
        /*---- ジャンプ ----*/
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);

        }

        /*---- リセット ----*/
        if (Input.GetKey(KeyCode.R))
        {
            int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;//今のシーン
            SceneManager.LoadScene(nowSceneIndexNumber);
        }
    }

    /*---- 床との判定 ----*/
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
            /*---- ボックスとプレイヤーの処理 ----*/
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (Power >= 1)
                {
                    if (isLeft)
                    {
                        Instantiate(particlePrefab, new Vector3(collision.transform.position.x, collision.transform.position.y - 1, 0), Quaternion.identity);
                        Instantiate(particlePrefab, new Vector3(collision.transform.position.x, collision.transform.position.y - 1, 0), Quaternion.identity);
                        collision.transform.Translate(-2, 0, 0);
                    }
                    else if (isRight)
                    {
                        Instantiate(particlePrefab, new Vector3(collision.transform.position.x, collision.transform.position.y - 1, 0), Quaternion.identity);
                        Instantiate(particlePrefab, new Vector3(collision.transform.position.x, collision.transform.position.y - 1, 0), Quaternion.identity);
                        collision.transform.Translate(2, 0, 0);
                    }
                }
                Power -= 1;
            }
            //ボックスの破壊
            if (Input.GetKeyDown(KeyCode.X))
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
