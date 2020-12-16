using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float moveSpeed;//移动速度
    private Vector3[] allPoints;//所有点的数组
  
    public int currPoint;//当前点
    private SelfAnim animator;

    private int childPathIdx;

    void Start()
    {
        animator = GetComponent<SelfAnim>();
        InitOnePath();
    }
    private void InitOnePath()
    {
        allPoints = PathMgr.Instance.GetPath(out childPathIdx);
        allPoints[0].x = transform.position.x;
        currPoint = 0;
    
    }

    void Update()
    {
        if (GameMgr.Instance.isStartGame)
        {
            transform.position = Vector3.MoveTowards(transform.position, allPoints[currPoint], Time.deltaTime * moveSpeed);
            if (transform.position == allPoints[currPoint])
            {
                Vector3 prev = allPoints[currPoint];
                currPoint++;
                if (currPoint >= allPoints.Length)
                {
                    Debug.Log("当前巡逻结束");
                    PathMgr.Instance.BackPath(childPathIdx);
                    InitOnePath();
                }
                Vector3 next = allPoints[currPoint];
                CalculateDir(prev, next);
            }
        }
    }
    private void CalculateDir(Vector3 prev,Vector3 next)
    {
        float xx = next.x - prev.x;
        float yy = next.y - prev.y;
        if(Mathf.Abs(yy)> Mathf.Abs(xx))
        {
            animator.ChangeDir(yy > 0 ? SelfAnim.MoveDirAnim.Up : SelfAnim.MoveDirAnim.Down);

        }
        else
        {
            animator.ChangeDir(yy > 0 ? SelfAnim.MoveDirAnim.Right : SelfAnim.MoveDirAnim.Left);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameMgr.Instance.GameOver(false);
        }
    }
}
