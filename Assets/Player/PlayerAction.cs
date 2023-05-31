using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class PlayerAction : MonoBehaviour
{
    //public GameObject box;
    public GameObject particlePrefab;
    public GameObject breakParticle;
    //電池
    public GameObject denti1;
    public GameObject denti2;
    public GameObject denti3;
    public GameObject denti4;
    public GameObject denti5;
    public GameObject denti6;
    public GameObject denti7;
    public GameObject denti8;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;
    public GameObject obj7;
    public GameObject obj8;

    Rigidbody2D rigidbody2D;

    private string boxTag = "Box";
    private string floorTag = "Floor";
    private string goalTag = "Goal";
    public GameObject[] dentiArray = new GameObject[3];


    /*---- 変数宣言 ----*/
    public float moveSpeed = 0.005f;
    public float jumpPower = 80.0f;
    public int dentiPoint = 3;

    float xLimit = 26.0f;
    float yLimit = 18.0f;
    bool isRight = false;
    bool isLeft = true;
    bool isBreak = false;
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
        obj1 = Instantiate(denti1, new Vector3(12.5f, 6, 0), Quaternion.identity);
        obj2 = Instantiate(denti1, new Vector3(11.5f, 6, 0), Quaternion.identity);
        obj3 = Instantiate(denti1, new Vector3(10.5f, 6, 0), Quaternion.identity);
        if (SceneManager.GetActiveScene().name == "Stage2")
        {
            obj4 = Instantiate(denti1, new Vector3(9.5f, 6, 0), Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().name == "Stage3")
        {
            obj4 = Instantiate(denti1, new Vector3(9.5f, 6, 0), Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().name == "Stage4")
        {
            obj4 = Instantiate(denti1, new Vector3(9.5f, 6, 0), Quaternion.identity);
            obj5 = Instantiate(denti1, new Vector3(8.5f, 6, 0), Quaternion.identity);
            obj6 = Instantiate(denti1, new Vector3(7.5f, 6, 0), Quaternion.identity);
            obj7 = Instantiate(denti1, new Vector3(6.5f, 6, 0), Quaternion.identity);
            obj8 = Instantiate(denti1, new Vector3(5.5f, 6, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        particleTime++;
        /*---- キー移動 ----*/
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            this.GetComponent<SpriteRenderer>().flipX = true;
            isRight = false;
            isLeft = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            this.GetComponent<SpriteRenderer>().flipX = false;
            isRight = true;
            isLeft = false;
        }
        /*---- ジャンプ ----*/
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);

        }
        if (isBreak)
        {
            GameObject effect = Instantiate(breakParticle) as GameObject;
            effect.transform.position = transform.position;
            isBreak = false;
        }

        /*----- 電池 ----*/
        if (dentiPoint <= 7)
        {
            Destroy(obj8);
        }
        if (dentiPoint <= 6)
        {
            Destroy(obj7);
        }
        if (dentiPoint <= 5)
        {
            Destroy(obj6);
        }
        if (dentiPoint <= 4)
        {
            Destroy(obj5);
        }
        if (dentiPoint <= 3)
        {
            Destroy(obj4);
        }
        if (dentiPoint <= 2)
        {
            Destroy(obj3);
        }
        if (dentiPoint <= 1)
        {
            Destroy(obj2);
        }
        if (dentiPoint <= 0)
        {
            Destroy(obj1);
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
                if (dentiPoint >= 1)
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
                    dentiPoint -= 1;

                }
            }
            //ボックスの破壊
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (dentiPoint >= 1)
                {

                    isBreak = true;
                    Destroy(collision.gameObject);
                    dentiPoint -= 1;
                }
            }
        }
    }
}
