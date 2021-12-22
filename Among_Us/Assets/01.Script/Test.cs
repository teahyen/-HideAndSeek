using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Material _mainMat;
    void Start()
    {
        _mainMat = GetComponent<SpriteRenderer>().material;
        Sprite sp= GetComponent<SpriteRenderer>().sprite;
        _mainMat.SetTexture("_MainTex", sp.texture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
