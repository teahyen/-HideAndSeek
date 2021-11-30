using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator move;

    public float speed;
    public bool isLift = true;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetAxisRaw("Horizontal")> 0||Input.GetAxisRaw("Vertical") != 0&&isLift){
            move.Play("Right");
            isLift = false;
        }else if(Input.GetAxisRaw("Horizontal")< 0||Input.GetAxisRaw("Vertical") != 0&&!isLift){
            move.Play("Lift");
            isLift = true;
        }else if(isLift){
            move.Play("Idle_r");
        }else{
            move.Play("Idle");
        }
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * Time.deltaTime*speed;

        if(Input.GetKeyDown(KeyCode.F)){
            //나중에 상호작용 할꺼임
        }
    }
}
