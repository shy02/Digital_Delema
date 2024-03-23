using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPoint : MonoBehaviour
{
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.GetChild(0);
        player.position = new Vector3(-7.6f, -6.13f, -5.2f);
    }

    // Update is called once per frame
    void Update()
    {
        switch(SceneManager.GetActiveScene().name){
            case "1":
            player.position = new Vector3(-0.18f, -6.13f, -5.2f);
            break;
            case "2":
            player.position = new Vector3(19.8f, -6.13f, -5.2f);
            break;
            case "3":
            player.position = new Vector3(38.7f, -6.13f, -5.2f);
            break;
            case "4":
            player.position = new Vector3(58.3f, -6.13f, -5.2f);
            break;
            case "5":
            player.position = new Vector3(90.01f, -6.9f, -5.2f);
            break;
            default:
            break;

        }
    }
}
