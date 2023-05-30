using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManeger : MonoBehaviour
{
    public GameObject BoxPrefab;


    // Start is called before the first frame update
    void Start()
    {

        Instantiate(BoxPrefab, new Vector3(5, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

