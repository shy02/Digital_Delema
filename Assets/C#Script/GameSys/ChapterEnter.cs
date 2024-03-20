using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterEnter : MonoBehaviour
{
    [SerializeField] string ChNum;
    [SerializeField] GameObject ExplainUI;

    void Start(){
        ExplainUI = transform.GetChild(0).gameObject;
        ExplainUI.SetActive(false);
    }

   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") ExplainUI.SetActive(true);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
            if(Input.GetKey(KeyCode.Space)){
                Debug.Log("하하하");
                SceneManager.LoadScene("1");
            }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ExplainUI.SetActive(false);
        }
    }
}
