using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void GameQuit()
    {
        Application.Quit();//退出游戏
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        Application.Quit();
    //    }
    //}
}
