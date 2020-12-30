using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;

    public void GameOverAD(bool iswin)
    {
        //触发GameOverAD时，判断胜负
        if (iswin)
        {
            //胜
            audioSource.clip = audioClip;//更换声音
            audioSource.Play();//播放
        }
        else
        {
            //负
            audioSource.clip = audioClip;//更换声音
            audioSource.Play();//播放
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//获取audioSource组件
    }
}
