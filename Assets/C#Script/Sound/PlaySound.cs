using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySound : MonoBehaviour
{
    string recentStage = "";
    [SerializeField] AudioSource ClickSound;
    [SerializeField] AudioSource BGM;
    [SerializeField] List<AudioClip> sounds;
    [Header ("Other")]
    [Tooltip ("사운드랑 상관없지만 기능 우려먹을려고 넣음")]
    [SerializeField] C_ClickButton clickbtn;
    void Awake(){
        recentStage = SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        if(recentStage != SceneManager.GetActiveScene().name){
            if(clickbtn.isopdisplay){
                clickbtn.OptionButton();
            }
            ChangeStageBGM();
            recentStage = SceneManager.GetActiveScene().name;
        }
        if(Input.GetMouseButtonDown(0)){
            ClickSound.Play();
        }
        
    }

    public void ChangeStageBGM(){
        switch(SceneManager.GetActiveScene().name){
            case "Start":
            BGM.clip = sounds[0];
            BGM.Play();
            break;
            case "StageSelet":
            BGM.clip = sounds[1];
            BGM.Play();
            break;
            case "CH1": case "CH2": case "CH3": case "CH4": 
            BGM.clip = sounds[2];
            BGM.Play();
            break;
            case "CH1_BE": case "CH2_BE": case "CH3_BE": case "CH4_BE": 
            BGM.clip = sounds[3];
            BGM.Play();
            break;
            case "CH1_GE": case "CH2_GE": case "CH3_GE": case "CH4_GE": 
            BGM.clip = sounds[4];
            BGM.Play();
            break;
            case "1": case "2": case "3": case "4": 
            BGM.clip = sounds[5];
            BGM.Play();
            break;
            case "5":
            BGM.clip = sounds[6];
            BGM.Play();
            break;
        }
    }
}
