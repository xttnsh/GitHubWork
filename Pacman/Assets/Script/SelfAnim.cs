using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfAnim : MonoBehaviour
{
    public enum MoveDirAnim
    {
        None=-1,
        Right = 0,
        Left,
        Up,
        Down
    }

    public float AnimSpeed;//动画速度（间隔时间）
    public Sprite[] spritesArr;//Sprite数组
    private SpriteRenderer spriteRenderer;//Sprite渲染
    private int cuffFrame = 0;//当前帧
    private int startFrame;//开始帧
    private int endFrame;//结束帧
    public int totalFrame = 3;//每种动画的总帧数

    private MoveDirAnim currDir=MoveDirAnim.None;//用于记录当前方向

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();//获取Sprite渲染组件
        ChangeDir(MoveDirAnim.Right);
        StartCoroutine(PlayAnim());//协程
    }
    IEnumerator PlayAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(AnimSpeed);//等待AnimSpeed时间后执行
            spriteRenderer.sprite = spritesArr[cuffFrame];//更改组件sprite
            cuffFrame++;
            if (cuffFrame >= endFrame)
            {
                cuffFrame = startFrame;
            }
        }
    }
    public void ChangeDir(MoveDirAnim dir)
    {
        if (currDir==dir)
        {
            return;
        }
        else
        {
            currDir = dir;
            startFrame = (int)dir * totalFrame;
            cuffFrame = startFrame;
            endFrame = startFrame + totalFrame;
        }
    }


    void Update()
    {

    }
}
