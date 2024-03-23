using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("GameState")]
    public bool GameStart = false;

    [Header ("BlockSystem")]
    [SerializeField] List<GameObject> blockitem = new List<GameObject>();
    [SerializeField] int BlockCount;
    bool startblock = false;
    [Tooltip ("방해를 시작하는 시간")]
    [SerializeField] float BlockTime;//방해시작시간
    [Tooltip ("방해가 지속되는 시간")]
    [SerializeField] float BlockStay;//지속시간
    [Tooltip ("방해물이 재생성되는 텀")]
    [SerializeField] float delay1;
    [Tooltip ("시작시간 0 부터 ")]
    [SerializeField] float delay2;
    [Tooltip ("끝나는 시간 /이 시간 까지/")]
    float BlockDelay;//방해물 재생성텀
    [SerializeField] bool isBlockTwo;
    [Tooltip ("시간에 따라 빨라지나?")]
    [SerializeField] bool isFOT;

    [Header ("Hint")]
    [Tooltip ("힌트를 시작하는 시간")]
    [SerializeField] float HintTime;
    bool hint = false;
    float currentTime;

    [Header ("INIT")]
    [SerializeField] C_Timer timer;
    [SerializeField] C_FadeInOUT fade;
    [SerializeField] C_MousePosition MsPos;
    public AudioSource Clear;

    void Start(){
        StartCoroutine("WaitGame");
    }

    void Update()
    {
        timer.GameStart = this.GameStart;
        MsPos.GameStart = this.GameStart;

        currentTime = timer.currentTime;
        if(!startblock && this.GameStart && timer.MaxTime - currentTime <= BlockTime){
            StartCoroutine("BlockGame");
            startblock = true;
        }
        if(!hint && this.GameStart &&timer.MaxTime - currentTime <= HintTime){
            StartCoroutine("Hint");
            hint = true;
        }

    }
    IEnumerator WaitGame(){
        yield return new WaitForSeconds(5f);
        fade.FadeOUT();
        this.GameStart = true;
    }
    IEnumerator Hint(){
        fade.FadeIN();
        yield return new WaitForSeconds(3f);
        fade.FadeOUT();
    }

    IEnumerator BlockGame(){
        //시간에 따라 빨라질 경우
        BlockDelay = Random.Range(delay1, delay2);
        if(isFOT){
            BlockDelay = BlockDelay - ((currentTime - HintTime)/10);
        }
            Debug.Log(BlockDelay);
        if(isBlockTwo){
            //한개~두개 생성
            int oneTwo = Random.Range(0,2);
            switch(oneTwo){
                case 0 ://한개일 경우
                int Block = Random.Range(0,BlockCount);

                blockitem[Block].SetActive(true);
        
                yield return new WaitForSeconds(BlockStay);//s

                blockitem[Block].SetActive(false);

                yield return new WaitForSeconds(BlockDelay);

                StartCoroutine("BlockGame");
                    break;
                case 1 ://두개일 경우
                    int [] arrBlock = new int[2];

                    arrBlock[0] = Random.Range(0,BlockCount);
                    arrBlock[1] = Random.Range(0,BlockCount);

                    while(arrBlock[0] == arrBlock[1]){
                        arrBlock[1] = Random.Range(0,BlockCount);
                    }
                    blockitem[arrBlock[0]].SetActive(true);
                    blockitem[arrBlock[1]].SetActive(true);

                    yield return new WaitForSeconds(BlockStay);

                    blockitem[arrBlock[0]].SetActive(false);
                    blockitem[arrBlock[1]].SetActive(false);

                    yield return new WaitForSeconds(BlockDelay);
                    StartCoroutine("BlockGame");

                    break;
            }
        }
        else{//랜덤개수가 아닐경우
            int arrBlock = Random.Range(0,BlockCount);

            blockitem[arrBlock].SetActive(true);
        
            yield return new WaitForSeconds(BlockStay);

            blockitem[arrBlock].SetActive(false);

            yield return new WaitForSeconds(BlockDelay);

            StartCoroutine("BlockGame");
        }
    }
}
