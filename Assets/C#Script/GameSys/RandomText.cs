using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomText : MonoBehaviour
{
    [SerializeField] List <string> Talk = new List<string>();
    List <GameObject> blockitems = new List<GameObject>();
    List <bool> ishave = new List<bool>();
    int child;
    int ran;
    
    void Start()
    {
        child = transform.childCount;
        for(int i = 0; i < child; i++){
            if(transform.GetChild(i) != null){
                blockitems.Add(transform.GetChild(i).gameObject);
                ishave.Add(false);
            }
        }
    }

    void Update(){
        for(int i =0; i<child; i++){
            if(blockitems[i].activeSelf == true && !ishave[i]){
                ran = Random.Range(0,child);
                blockitems[i].transform.GetChild(0).GetComponent<Text>().text = Talk[ran];
                ishave[i] = true;
            }
            if(blockitems[i].activeSelf == false){
                ishave[i] = false;
            }
        }
    }


}
