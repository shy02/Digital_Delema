using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;


public class Old_Area : MonoBehaviour
{
    [SerializeField] GameObject PC;
    [SerializeField] UnityEngine.U2D.Animation.SpriteResolver head_Resolver;

    void Start(){
        PC = GameObject.Find("DontDestroyOnLoad").transform.GetChild(0).gameObject;
        head_Resolver = PC.transform.GetChild(5).transform.gameObject.GetComponent<SpriteResolver>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("늙어졌어용");
            head_Resolver.SetCategoryAndLabel("Head", "Entry_0");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("젊어졌어용");
            head_Resolver.SetCategoryAndLabel("Head", "Entry");
        }
    }
}
