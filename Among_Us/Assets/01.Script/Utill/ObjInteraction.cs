using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// public static class ObjInteraction : using UnityEngine;

public class ObjInteraction : MonoBehaviour
{
    //조금 가까이 가면 아웃 라인이 생기고
    //상호작용이 가능할 정도로 가까이 오면 오브젝트가 노랗게 변함
    private SpriteOutline outLine;
    public GameObject onBtnObj;

    public LayerMask player;

    public bool newrPlayer;

    public GameObject raisepanel;

    private void Start() {
        outLine = GetComponent<SpriteOutline>();
        onBtnObj.SetActive(false);
        onBtnObj.GetComponent<Button>().onClick.AddListener(()=>{

        });
    }
    private void Update() {
        newrPlayer = Physics2D.OverlapCircle(transform.position,4,player);
    }
}
