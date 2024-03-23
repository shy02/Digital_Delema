using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_ClickButton : MonoBehaviour
{
    [SerializeField] GameObject optionUI;
    bool isopdisplay = false;
    public void OptionButton(){
        if(isopdisplay){
            optionUI.SetActive(false);
            isopdisplay = false;
        }
        else{
            optionUI.SetActive(true);
            isopdisplay = true;
        }
    }

    public void Continue(){
        optionUI.SetActive(false);
        isopdisplay = false;
    }
    public void Return_Main(){
        SceneManager.LoadScene("Start");
    }
}
