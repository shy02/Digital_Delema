using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Move : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] float Xpos, Ypos, Zpos;
    //[SerializeField] float Background_Width = 120f;
    [SerializeField] float Background_Height = 17f;

    //float Camera_Width = (16f / 9f) * 5f;
    float Camera_Height = 5f;

    [SerializeField] float Camera_Speed = 12.0f;

    Vector3 Camera_Pos;

    private void FixedUpdate()
    {
        float Ylimit;
        //Xlimit = (Background_Width/2) - Camera_Width;
        Ylimit = (Background_Height/2) - Camera_Height;
        //Xlimit = Background_Width-(Camera_Width*2);
        float Xclamp, Yclamp;
        //Xclamp = Mathf.Clamp(Target.transform.position.x+Xpos, 0,  Xlimit);
        Xclamp = Mathf.Clamp(Target.transform.position.x + Xpos, 7, 86);
        Yclamp = Mathf.Clamp(Target.transform.position.y+Ypos, -Ylimit,  Ylimit);

        Camera_Pos = new Vector3(Xclamp, Yclamp, Zpos);

        transform.position = Vector3.Lerp(transform.position, Camera_Pos, Time.deltaTime * Camera_Speed);

    }
}
