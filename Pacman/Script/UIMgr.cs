using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameover;
    public GameObject win;

    public void StartGameUI()
    {
        panel.SetActive(false);//隐藏面板
    }
    public void GameOverUI(bool iswin)
    {
        //触发GameOverUI时，判断胜负
        if (iswin)    
        {
            //胜
            win.SetActive(true);//显示win
        }
        else
        {
            //负
            gameover.SetActive(true);//显示gameover
        }
    }
}
