using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMgr : MonoBehaviour
{
    public static PathMgr Instance;

    private List<int> canUsePath;
    void Awake()
    {
        Instance = this;
        canUsePath = new List<int>();
        for(int i = 0; i < transform.childCount; i++)
        {
            canUsePath.Add(i);
        }
    }


    public Vector3[] GetPath(out int childPathIdx)
    {   
        //随机获取路径


        int randomIdx = Random.Range(0, canUsePath.Count);
        childPathIdx = canUsePath[randomIdx];
        canUsePath.Remove(childPathIdx);
        Transform child = transform.GetChild(childPathIdx);
        Vector3[] result = new Vector3[child.childCount];
        for (int i = 0; i < child.childCount; i++)
        {
            result[i] = child.GetChild(i).position;
        }
        return result;
    }
    public void BackPath(int childPathIdx)
    {
        canUsePath.Add(childPathIdx);
    }

}
