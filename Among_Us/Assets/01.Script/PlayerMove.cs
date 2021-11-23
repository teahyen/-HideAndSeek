using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator move;

    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetAxisRaw("Horizontal")> 0){
            move.Play("Right");
        }
        if(Input.GetAxisRaw("Horizontal")< 0){
            move.Play("Lift");
        }
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * Time.deltaTime*speed;

        if(Input.GetKeyDown(KeyCode.F)){
            //나중에 상호작용 할꺼임
        }
    }
}
