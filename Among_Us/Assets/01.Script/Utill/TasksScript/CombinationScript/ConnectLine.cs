using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectLine : MonoBehaviour
{
    public Image lineImg;
    public Button startPos;
    private Vector3 mousePos;

    //���⼭ �� ������ ����
    public float connectRange;
    public LayerMask endLayer;
    public bool isEnd;
    Collider2D endCol;
    public List<GameObject> endObj = new List<GameObject>();

    public GameObject headLine;

    void Start()
    {
        for (int i = 1; i <= 4; i++)
        {
            endObj.Add(GameObject.Find($"EndPos{i}"));
        }
        GameObject p = transform.parent.gameObject;
        print(p.name);
        if (p.name.Contains("End"))
            Destroy(this);
        //startPos.onClick.AddListener(() =>
        //{
        //    print("�����");
        //    lineImg.gameObject.SetActive(true);
        //    mousePos = Input.mousePosition;
        //    lineImg.transform.position = startPos.transform.position;
        //    headLine.transform.position = startPos.transform.position;
        //});
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            print("����?");
            lineImg.gameObject.SetActive(true);
            mousePos = Input.mousePosition;
            lineImg.transform.position = startPos.transform.position;
            headLine.transform.position = startPos.transform.position;
        }

        //�̶� �Ӹ� �κе� ���� �����̰� �ؾ��Ѵ�.
        if (Input.GetMouseButton(0))
        {
            Vector3 myPos = Input.mousePosition;
            lineImg.transform.localScale = new Vector2(Vector3.Distance(myPos, mousePos)/29, 1);
            lineImg.transform.localRotation = Quaternion.Euler(0, 0,
                AngleInDeg(mousePos, myPos));




            headLine.transform.position = Input.mousePosition;
            headLine.transform.localRotation = Quaternion.Euler(0, 0,
                AngleInDeg(mousePos, myPos));

        }

        //isEnd = Physics2D.OverlapCircle(transform.position, connectRange, endLayer);
        //endCol = Physics2D.OverlapCircle(transform.position, connectRange, endLayer);
        
        if (Input.GetMouseButtonUp(0)/*&&!isEnd*/)
        {
            headLine.transform.rotation = Quaternion.Euler(0,0,0);
            //���� ������ ������ �� �Լ��� ���� ��Ű�� �ȵȴ�.
            lineImg.gameObject.SetActive(false);
            headLine.transform.position = startPos.transform.position;
        }
        //else if(Input.GetMouseButtonUp(0) && isEnd)
        //{
        //    lineImg.gameObject.SetActive(true);
        //    headLine.transform.position = endCol.transform.position;
        //}
    }

    public static float AngleInRad(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
    }

    public static float AngleInDeg(Vector3 vec1, Vector3 vec2)
    {
        return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    for (int i = 1; i <= 4; i++)
    //    {
    //        Gizmos.DrawWireSphere(endObj[i].transform.position, connectRange);
    //    }
    //}
}
