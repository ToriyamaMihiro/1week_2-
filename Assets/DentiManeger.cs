using UnityEngine;
using System;
using System.Collections;

public class DentiManeger : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[3];
    private int lifePoint = 3;

    public void Denti(int dentiPoint)
    {
        lifeArray[lifePoint - 1].SetActive(false);
        lifePoint--;
    }
    void Update()
    {
        
    }
}
