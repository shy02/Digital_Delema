using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] float PC_Speed = 7.0f;
    [SerializeField] GameObject PC;
    Rigidbody2D rigid;
    Animator anim;

    Vector3 PC_Pos;
    float scaleX, scaleY, scaleZ;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        PC_Pos = PC.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PC_Move();
    }

    void PC_Move()
    {
        if(PC.transform.position == PC_Pos)
        {
            anim.SetBool("isMove", false);
        }
        else
        {
            PC_Pos = PC.transform.position;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(PC_Speed * Time.deltaTime, 0, 0));
            anim.SetBool("isMove", true);

            scaleX = transform.localScale.x;
            scaleY = transform.localScale.y;
            scaleZ = transform.localScale.z;
            if (scaleX > 0)
            {
                transform.localScale = new Vector3(-scaleX, scaleY, scaleZ);
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-PC_Speed * Time.deltaTime, 0, 0));
            anim.SetBool("isMove", true);

            scaleX = transform.localScale.x;
            scaleY = transform.localScale.y;
            scaleZ = transform.localScale.z;
            if (scaleX < 0)
            {
                transform.localScale = new Vector3(-scaleX, scaleY, scaleZ);
            }
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, PC_Speed * Time.deltaTime, 0));
            anim.SetBool("isMove", true);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -PC_Speed * Time.deltaTime, 0));
            anim.SetBool("isMove", true);
        }
    }
}
