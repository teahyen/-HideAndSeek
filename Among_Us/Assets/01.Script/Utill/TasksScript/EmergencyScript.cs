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
        //플래이어를 멈춤
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        //투표시작
        emergencyBtn.onClick.AddListener(() =>
        {
            print("대원들 전부 소집");
        });
        //나가기 버튼
        exitBtn.onClick.AddListener(() =>
        {
            ExitBtn();
        });
        //처음에 뚜껑 닫친거
        shellCover.SetActive(true);
        openCover.SetActive(false);
    }

    void Update()
    {
        //위험 버튼이면 카운트 시작
        if (startCount)
        {
            startCount = false;
            playerMove.enabled = false;
            count = 10;
        }
        if(count > 1)
        {
            //카운트다운
            count -= Time.deltaTime;
            countTex.text = ((int)count).ToString();
        }
        else
        {
            //카운트가 0이 되면 뚜껑이 열림
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
