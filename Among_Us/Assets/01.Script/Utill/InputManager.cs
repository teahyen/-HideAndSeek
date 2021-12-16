using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public enum OnPenalMode
{
    //�Ʒ����� ��
    defualt,
    //���� ������ ����(������ ����)
    Lazer,
    //���̵��� ���̵� �ƿ�
    CCTV
}
public class InputManager : MonoBehaviour
{
    public GameObject raisepanel;

    public OnPenalMode onPenalMode;

    public bool isEmergency = false;

    PlayerMove playerMove;

    void Start()
    {
        //�÷��̾ ����
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        switch (onPenalMode)
        {
            case OnPenalMode.defualt:
                print("������");
                raisepanel.transform.localPosition += new Vector3(0,-900,0);
                break;


            case OnPenalMode.Lazer:
                break;

            case OnPenalMode.CCTV:
                break;
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray,out rayHit))
            {
                if (rayHit.transform.gameObject.CompareTag("Button"))
                {
                    OpenPanel();
                }
            }
        }


    }

    public void OpenPanel()
    {
        print("��ư�� ���ɼ�");
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        playerMove.enabled = false;
        switch (onPenalMode)
        {
            case OnPenalMode.defualt:
                raisepanel.transform.DOLocalMoveY(0, 0.3f);
                if (isEmergency)
                {
                    raisepanel.GetComponent<EmergencyScript>().startCount = true;
                }
                break;


            case OnPenalMode.Lazer:
                break;

            case OnPenalMode.CCTV:
                break;
        }
    }

    public void OnPanel()
    {
        playerMove.enabled = false;
    }
}
