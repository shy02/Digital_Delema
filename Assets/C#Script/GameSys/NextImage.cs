using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextImage : MonoBehaviour
{
    Image StoryImage;
    int count_of_Image;
    [SerializeField] List<Sprite> Img = new List<Sprite>();
    [SerializeField] float ImgDelay;
    [SerializeField] bool isStart;
    void Start()
    {
        StoryImage = GetComponent<Image>();
        count_of_Image = Img.Count;
        StartCoroutine("StoryFlow");
    }

    IEnumerator StoryFlow(){
        for(int i = 0; i < count_of_Image+1; i++){
        yield return new WaitForSeconds(ImgDelay);
        if(i == count_of_Image){
            if(isStart){
            SceneManager.LoadScene("Ch"+SceneManager.GetActiveScene().name);//CH + 챕터 숫자 = 씬으로 불러오기
            }
            else {
                SceneManager.LoadScene("StageSelet");
            }
        }else{
        StoryImage.sprite = Img[i];
        }}
    }
}
