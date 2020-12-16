using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacdocOver : MonoBehaviour
{
    public int remainNum
    {
        get;
        private set;
    }
    // Start is called before the first frame update
    void Start()
    {
        remainNum = transform.childCount;
        //GameObject.FindObjectsOfType<Pacdoc>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        remainNum = transform.childCount;
    }
}
