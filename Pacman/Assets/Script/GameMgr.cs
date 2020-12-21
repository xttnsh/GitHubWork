using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    private const float WAIT_RELOAD = 4f;
    public static GameMgr Instance;

    public UIMgr uiMgr;
    public AudioMgr audioMgr;

    public bool isStartGame
    {
        get;
        private set;
    }

    public PacdocOver pacdocOver;

    void Awake()
    {
        Instance = this;
        isStartGame = false;
    }

    public void EatenDot()
    {
        if (pacdocOver.remainNum <= 0)
        {
            GameOver(true);
        }
    }

    public void StartGame()
    {
        isStartGame = true;
        uiMgr.StartGameUI();
    }
    public void GameOver(bool isWin)
    {
        isStartGame = false;

        if (isWin)
        {
            uiMgr.GameOverUI(true);
            audioMgr.GameOverAD(true);
            Debug.Log("游戏胜利");
        }
        else
        {
            uiMgr.GameOverUI(false);
            audioMgr.GameOverAD(false);
            Debug.Log("游戏结束");
        }
        Invoke("ReloadScene", WAIT_RELOAD);
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);

    }
    void Update()
    {
        EatenDot();

    }
}
