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

    //플래이어가 가까울때
    public bool newrPlayer;


    public int nearRange = 2;


    //front
    public bool frontPlayer;

    public float frontRange = 1.5f;

    private void Start() {
        onBtnObj.gameObject.SetActive(false);
        outLine.enabled = false;
    }
    private void Update()
    {
        Near();
        Front();

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

    private void Front()
    {
        frontPlayer = Physics2D.OverlapCircle(transform.position, frontRange, player);
        if (frontPlayer)
        {
            onBtnObj.SetActive(true);
        }
        else
        {
            onBtnObj.SetActive(false);
        }
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
