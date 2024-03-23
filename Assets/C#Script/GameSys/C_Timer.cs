using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class C_Timer : MonoBehaviour
{
    [Header ("Common")]
    public bool GameStart = false;
    [SerializeField] Image filcycle;
    [Header ("TimerSystem")]
    public float MaxTime;//초(sec)단위
    public float currentTime = 0f;//초(sec)단위
    float Addtime;
    [Header ("Sounds")]
    AudioSource Audio;
    [SerializeField] AudioClip ClearSounds;
    [Header ("INIT")]
    [SerializeField] GameManager Gm;

    RectTransform rect;

    void Start(){
        rect = this.GetComponent<RectTransform>();
        Addtime = 360f / MaxTime;
        Audio = Gm.Clear;
    }
    void Update()
    {
        if(GameStart){
        if(currentTime < MaxTime){
          currentTime += Time.deltaTime;
          rect.Rotate(new Vector3(0,0,-Time.deltaTime * Addtime));//최종값 360
          filcycle.fillAmount = currentTime / MaxTime;
         }
        else if(GameStart){
            Gm.GameStart = false;
            StartCoroutine("FailGame");
         }
        }
    }
    IEnumerator FailGame(){
            Audio.clip = ClearSounds;
            Audio.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name+"_BE");
    }
}
