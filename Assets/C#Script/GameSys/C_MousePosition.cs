using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.Audio;

public class C_MousePosition : MonoBehaviour
{
    [Header ("Count")]
    [SerializeField] int MaxCheckCount;
    [SerializeField] List<bool> IsCheck = new List<bool>();
    int CheckCount = 0;
    [Header ("Common")]
    public bool GameStart = false;
    [Header ("Point")]
    [SerializeField] List<Vector2> first_point = new List<Vector2>();
    [SerializeField] List<Vector2> second_point= new List<Vector2>();
    [Tooltip("정답 표시 아이콘 > 0 = 1, 1 = 2...")]
    [SerializeField] List<GameObject> RightSign = new List<GameObject>();
    [Header ("Sounds")]
    AudioSource Audio;
    Slider BGM_slider;
    float BGM_val;
    [SerializeField] AudioMixer Sound;
    [SerializeField] AudioClip ClearSounds;
    [Header ("INIT")]
    [SerializeField] GameManager Gm;
    [SerializeField] C_Timer timer;
    [SerializeField] Camera Came;
    [SerializeField] Text T_count;
    Vector2 MPosition;

    void Start(){
        T_count.text = ("0/" + MaxCheckCount);
        Audio = Gm.Clear;
        BGM_slider = GameObject.Find("DontDestroyOnLoad").transform.GetChild(1).GetChild(1).GetChild(4).gameObject.GetComponent<Slider>();
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MPosition = Input.mousePosition;
            MPosition = Camera.main.ScreenToWorldPoint(MPosition);

            transform.position = MPosition;
            Debug.Log(MPosition);
            if(GameStart){
                for(int i = 0; i < MaxCheckCount; i++){
                    CheckSystem(first_point[i], second_point[i], i);
                }
            }
        }
        
        if(MaxCheckCount == CheckCount && Gm.GameStart){
            Gm.GameStart = false;
            StartCoroutine("ClearGame");
        }
    }
    void CheckSystem(Vector2 F, Vector2 S, int i){
        if(MPosition.x >= F.x && MPosition.x <= S.x && MPosition.y > F.y && MPosition.y < S.y){
            if(!IsCheck[i]){
            //Debug.Log("정답입니다.");
            IsCheck[i] = true;
            RightSign[i].SetActive(true);
            CheckCount++;
            T_count.text = (CheckCount + "/" + MaxCheckCount);
            }
        }
        else{
            //Debug.Log("오답입니다.");
        }
    }
    IEnumerator ClearGame(){
        BGM_val = BGM_slider.value;
        Audio.clip = ClearSounds;
        Sound.SetFloat("BGM", -80f);
        Audio.Play();
        yield return new WaitForSeconds(3.5f);
        Sound.SetFloat("BGM", BGM_val);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name +"_GE");
    }
}
