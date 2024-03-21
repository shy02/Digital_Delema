using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_DontDestroyOnLoad : MonoBehaviour
{
    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
}
