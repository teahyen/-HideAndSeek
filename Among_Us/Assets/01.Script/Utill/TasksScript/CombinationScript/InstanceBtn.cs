using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBtn : MonoBehaviour
{
    public List<GameObject> parent = new List<GameObject>();
    public CombinationManager CM;
    public List<bool> isArticle= new List<bool>();

    void Start()
    {
        for (int i = 0; i < parent.Count; i++)
        {
            NoArticle(i);
        }
    }

    private void NoArticle(int i)
    {
        int sum = Random.Range(0, CM.lines.Count);
        //이미 나온 숫자일 경우 다시 시작
        if (isArticle[sum])
        {
            NoArticle(i);
        }
        //아닐경우 위치에 소환
        else
        {
            isArticle[sum] = true;
            GameObject line = Instantiate(CM.lines[sum], parent[i].transform);
            line.transform.localScale = new Vector3(1,1,1);
        }
    }

    void Update()
    {
        
    }
}
