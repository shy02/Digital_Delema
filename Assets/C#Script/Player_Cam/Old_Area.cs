using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Old_Area : MonoBehaviour
{
    [SerializeField] GameObject PC;
    [SerializeField] UnityEngine.U2D.Animation.SpriteResolver head_Resolver;

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
