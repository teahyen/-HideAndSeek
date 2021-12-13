using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Start()
    {
        raisepanel.SetActive(false);
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
                    print("��ư�� ���ɼ�");

                    switch (onPenalMode)
                    {
                        case OnPenalMode.defualt:
                            break;


                        case OnPenalMode.Lazer:
                            break;

                        case OnPenalMode.CCTV:
                            break;
                    }
                }
            }
        }
    }
}
