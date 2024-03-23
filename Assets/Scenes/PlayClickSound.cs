using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClickSound : MonoBehaviour
{
    [SerializeField] AudioSource ClickSound;
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            ClickSound.Play();
        }
    }
}
