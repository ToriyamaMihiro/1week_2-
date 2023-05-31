using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Denti : MonoBehaviour
{

    public GameObject[] lifeArray = new GameObject[3];
    private int lifePoint = 3;

    public void DentiMuinus(int dentiPoint)
    {
        lifeArray[lifePoint - 1].SetActive(false);
        lifePoint--;
    }
    void Update()
    {

    }
}
