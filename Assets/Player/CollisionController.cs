using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    Rigidbody2D rd; //Rigidbody�I�u�W�F�N�g
    float attspeed = 10.0f;  //�I�u�W�F�N�g�ړ��X�s�[�h
    private string boxTag = "Box";
    public GameObject player;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();   //Rigidbody�R���|�[�l���g�擾
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)|| Input.GetKeyDown(KeyCode.X))
        {//�U���J�n��(Space�L�[�������ƍU���J�n)
            rd.velocity = new Vector2(attspeed, 0); //�X�s�[�h�����čU���I�u�W�F�N�g���ړ�
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == boxTag) {
            Destroy(collision.gameObject);    //�U���I�u�W�F�N�g�̔j��
        }
       
    }
}
