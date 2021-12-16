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
        if(Input.GetAxisRaw("Horizontal")> 0){
            move.Play("Right");
            isLift = false;
        }else if(Input.GetAxisRaw("Horizontal")< 0){
            move.Play("Left");
            isLift = true;
        }else if(!isLift&& Input.GetAxisRaw("Vertical") != 0){
            move.Play("Right");
        }else if( isLift&& Input.GetAxisRaw("Vertical") != 0){
            move.Play("Left");
        }else if(Input.GetAxisRaw("Horizontal")== 0&& isLift){
            move.Play("Idle_L");
        }
        else{
            move.Play("Idle");
        }

        if(isLift){
            transform.rotation = new Quaternion(0,180,0,0);
        }
        else{
            transform.rotation = new Quaternion(0,0,0,0);
        }
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * Time.deltaTime*speed;

        if(Input.GetKeyDown(KeyCode.F)){
            //나중에 상호작용 할꺼임
        }


    }


}
