using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdoc : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //2D触发器
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);//销毁
        }

    }
}
