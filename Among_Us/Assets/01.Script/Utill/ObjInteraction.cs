using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// public static class ObjInteraction : using UnityEngine;

public class ObjInteraction : MonoBehaviour
{
    //조금 가까이 가면 아웃 라인이 생기고
    //상호작용이 가능할 정도로 가까이 오면 오브젝트가 노랗게 변함

    public SpriteRenderer outLine;
    public GameObject onBtnObj;
    public LayerMask player;

    public GameObject raisepanel;

    private Button useBtn;

    //플래이어가 가까울때
    public bool newrPlayer;


    public float nearRange = 2;

    ColorBlock colorBlock;
    //front
    public bool frontPlayer;

    public float frontRange = 1.5f;

    private void Start() {
        useBtn = GameObject.Find("CitizenUse").GetComponent<Button>();
        onBtnObj.gameObject.SetActive(false);
        raisepanel.transform.localPosition += new Vector3(0, -900, 0);
        outLine.enabled = false;

        //버튼 색깔 변경
        useBtn.enabled = true;
        colorBlock = useBtn.colors;
        colorBlock.normalColor = new Color(1f, 1f, 1f, 0.5f);
        useBtn.colors = colorBlock;
        useBtn.onClick.AddListener(() =>
        {
            Front(HandleOpen);
        });
    }
    private void Update()
    {
        Near();
        Front();
        if (Input.GetKeyDown(KeyCode.E))
        {
            Front(HandleOpen);
        }
    }

    private void Near()
    {
        newrPlayer = Physics2D.OverlapCircle(transform.position, nearRange, player);
        if (newrPlayer)
        {
            outLine.enabled = true;
        }
        else
        {
            outLine.enabled = false;
        }
    }

    private void Front(Action Handle = null)
    {
        frontPlayer = Physics2D.OverlapCircle(transform.position, frontRange, player);
        if (frontPlayer)
        {

            colorBlock.normalColor = new Color(1f, 1f, 1f, 1f);
            useBtn.colors = colorBlock;
            useBtn.enabled = true;
            if (Handle != null)
            {
                Handle();
            }

            onBtnObj.SetActive(true);
        }
        else
        {
            colorBlock.normalColor = new Color(1f, 1f, 1f, 0.5f);
            onBtnObj.SetActive(false);
        }

    }
    private void HandleOpen()
    {
        onBtnObj.GetComponent<InputManager>().OpenPanel();
    }

    private void OnDrawGizmosSelected()
    {
        //가까워요
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, nearRange);

        //ㅈㄴ가까워요
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, frontRange);
    }

}
