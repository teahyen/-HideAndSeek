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
        //�̹� ���� ������ ��� �ٽ� ����
        if (isArticle[sum])
        {
            NoArticle(i);
        }
        //�ƴҰ�� ��ġ�� ��ȯ
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
