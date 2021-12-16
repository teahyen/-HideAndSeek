using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationManager : MonoBehaviour
{
    //여러 색깔들의 선을 가지고 온다
    public List<GameObject> lines = new List<GameObject>();
    public Button exitBtn;
    PlayerMove playerMove;

    void Start()
    {
        //플래이어를 멈춤
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        exitBtn.onClick.AddListener(() =>
        {
            ExitBtn();
        });

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitBtn();
        }
    }

    public void ExitBtn()
    {
        CanMove();
        gameObject.transform.localPosition += new Vector3(0, -900, 0);
    }
    public void CanMove()
    {
        playerMove.enabled = true;
    }
}
