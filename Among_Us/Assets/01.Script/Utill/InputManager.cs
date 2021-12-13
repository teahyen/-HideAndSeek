using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum OnPenalMode
{
    //아래에서 위
    defualt,
    //가로 펴지고 세로(레이져 대포)
    Lazer,
    //페이드인 페이드 아웃
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
                    print("버튼이 눌령숑");

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
