using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class C_Area : MonoBehaviour
{
    [SerializeField]BackGround_Area backarea;
    [SerializeField] int num;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            backarea.areanum = num;
        }
    }
}
