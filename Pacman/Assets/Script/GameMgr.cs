using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    private const float WAIT_RELOAD = 5f;
    public static GameMgr Instance;
    public bool isStartGame
    {
        get;
        private set;
    }
    public GameObject panel;
    public GameObject gover;
    public GameObject win;
    public AudioSource audioSource;
    public AudioClip audioClip;

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
        panel.SetActive(false);//隐藏面板
    }
    public void GameOver(bool isWin)
    {
        isStartGame = false;

        if (isWin)
        {
            win.SetActive(true);
            Debug.Log("游戏胜利");
        }
        else
        {
            gover.SetActive(true);
            Debug.Log("游戏结束");
        }
        audioSource.clip = audioClip;
        audioSource.Play();
        Invoke("ReloadScene", WAIT_RELOAD);
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartGame(); 
        }
        EatenDot();

    }
}
