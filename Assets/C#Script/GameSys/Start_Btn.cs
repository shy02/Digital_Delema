using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Btn : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Button start_btn;
    [SerializeField] Button option_btn;
    [SerializeField] Button exit_btn;

    void Start()
    {
        start_btn.onClick.AddListener(start_click);
        option_btn.onClick.AddListener(option_click);
        exit_btn.onClick.AddListener(exit_click);
    }

    // Update is called once per frame

    void start_click()
    {
        SceneManager.LoadScene("StageSelet");
    }

    void option_click()
    {
        Debug.Log("옵션이에용");
    }

    void exit_click()
    {
        Debug.Log("나가기에용");
    }

    void Update()
    {
        
    }
}
