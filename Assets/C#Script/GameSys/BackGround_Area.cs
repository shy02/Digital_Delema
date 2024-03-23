using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Area : MonoBehaviour
{
    public int areanum = 1;
    [SerializeField] List<Sprite> Sky;
    Color color;
    void Start(){
        
    }
    void Update(){
        switch(areanum){
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = Sky[0];
                ColorUtility.TryParseHtmlString("#5F7C9C", out color);
                this.GetComponent<SpriteRenderer>().color =color;
            break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = Sky[0];
                ColorUtility.TryParseHtmlString("#FFFFFF", out color);
                this.GetComponent<SpriteRenderer>().color =color;
            break;
            case 3:
            this.GetComponent<SpriteRenderer>().sprite = Sky[1];
            ColorUtility.TryParseHtmlString("#FFFFFF", out color);
            this.GetComponent<SpriteRenderer>().color =color;
            break;
            case 4:
            this.GetComponent<SpriteRenderer>().sprite = Sky[2];
            ColorUtility.TryParseHtmlString("#827C9F", out color);
            this.GetComponent<SpriteRenderer>().color =color;
            break;
        }
    }
}
