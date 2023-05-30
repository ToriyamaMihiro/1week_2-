using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private string playerTag = "Player";
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void SceneLoad()
    {
        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(++nowSceneIndexNumber);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(particle) as GameObject;
        effect.transform.position = transform.position;
        if (collision.collider.tag == playerTag)
        {
            Invoke("SceneLoad", 1f);
        }
    }
}
