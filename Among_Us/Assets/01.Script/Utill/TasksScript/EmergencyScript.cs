using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmergencyScript : MonoBehaviour
{

    public GameObject openCover;
    public GameObject shellCover;
    public Button emergencyBtn;
    public Button exitBtn;

    public bool startCount = false;
    public float count;
    public Text countTex;
    PlayerMove playerMove;

    void Start()
    {
        //�÷��̾ ����
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        //��ǥ����
        emergencyBtn.onClick.AddListener(() =>
        {
            print("����� ���� ����");
        });
        //������ ��ư
        exitBtn.onClick.AddListener(() =>
        {
            ExitBtn();
        });
        //ó���� �Ѳ� ��ģ��
        shellCover.SetActive(true);
        openCover.SetActive(false);
    }

    void Update()
    {
        //���� ��ư�̸� ī��Ʈ ����
        if (startCount)
        {
            startCount = false;
            playerMove.enabled = false;
            count = 10;
        }
        if(count > 1)
        {
            //ī��Ʈ�ٿ�
            count -= Time.deltaTime;
            countTex.text = ((int)count).ToString();
        }
        else
        {
            //ī��Ʈ�� 0�� �Ǹ� �Ѳ��� ����
            shellCover.SetActive(false);
            openCover.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitBtn();
        }
    }
    public void CanMove()
    {
        playerMove.enabled = true;
    }
    public void ExitBtn()
    {
        CanMove();
        shellCover.SetActive(true);
        openCover.SetActive(false);
        gameObject.transform.localPosition += new Vector3(0, -900, 0);

    }


}
