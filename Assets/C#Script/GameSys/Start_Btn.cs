using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Start_Btn : MonoBehaviour
{
    // Start is called before the first frame update
    C_ClickButton clickbtn;
    Button start_btn, option_btn, exit_btn, Control_btn;
    GameObject control_img;
    Button Ctrl_X;
    bool is_control_display = false;
    void Start()
    {
        start_btn = transform.GetChild(4).gameObject.GetComponent<Button>();
        option_btn = transform.GetChild(5).gameObject.GetComponent<Button>();
        exit_btn = transform.GetChild(6).gameObject.GetComponent<Button>();
        Control_btn = transform.GetChild(7).gameObject.GetComponent<Button>();

        control_img = transform.GetChild(8).gameObject;
        Ctrl_X = control_img.transform.GetChild(1).gameObject.GetComponent<Button>();

        start_btn.onClick.AddListener(start_click);
        option_btn.onClick.AddListener(option_click);
        exit_btn.onClick.AddListener(exit_click);
        Control_btn.onClick.AddListener(Control_click);
        Ctrl_X.onClick.AddListener(Control_click);
        clickbtn = GameObject.Find("DontDestroyOnLoad").transform.GetChild(2).gameObject.GetComponent<C_ClickButton>();
    }

    // Update is called once per frame

    void start_click()
    {
        SceneManager.LoadScene("StageSelet");
    }

    void option_click()
    {
        clickbtn.OptionButton();
    }

    void Control_click(){
        if(!is_control_display){
            is_control_display = true;
            control_img.SetActive(true);
        }else{
            is_control_display = false;
            control_img.SetActive(false);
        }
    }

    void exit_click()
    {
        Application.Quit();
    }
}
