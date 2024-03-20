using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_FadeInOUT : MonoBehaviour
{
    Image crossImage;

    void Start(){
        crossImage = this.GetComponent<Image>();
    }
    public void FadeIN(){
        StartCoroutine("CoFadeIn");
    }
    public void FadeOUT(){
        StartCoroutine("CoFadeOut");
    }
    IEnumerator CoFadeIn()
    {
        int i = 0;
            while (i < 10)
            {
                i += 1;
                float f = i / 10.0f;
                Color c = crossImage.color;
                c.a = f;
                crossImage.color = c;
                yield return new WaitForSeconds(0.02f);
            }

    }
    IEnumerator CoFadeOut(){
        int i = 10;
        while (i > 0){
                i -= 1;
                float f = i / 10.0f;
                Color c = crossImage.color;
                c.a = f;
                crossImage.color = c;
                yield return new WaitForSeconds(0.02f);
        }
    }


}
