using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool fall;       //ブロックが落ちるフラグ
    float fallSpeed;    //ブロックの落ちる速さ

    bool countDown;     //ブロックが落ちるまでのカウントを開始するフラグ
    float time;         //ブロックが落ちるまでの時間


    Vector3 startPos;   //このブロックの初期位置
    Vector3 currentPos; //このブロックの現在位置

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;

        StateReset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (countDown == true)
        {
            if (time >= 0)
            {
                time = time - Time.deltaTime;
            }
            else
            {
                fall = true;
            }
        }
        

        //ブロック落下
        if (fall == true)
        {
            currentPos.y -= fallSpeed * Time.deltaTime;
            this.transform.position = currentPos;


            if (currentPos.y < -20)
            {
                StateReset();
            }
        }
    }

    void StateReset()
    {
        fall = false;
        fallSpeed = 3f;
        countDown = false;
        time = 5f;
        currentPos = startPos;
        this.transform.position = currentPos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))//Playerが床に接触すると一定時間経過後に床が落ちる
        {
            countDown = true;
        }
        if (collision.gameObject.CompareTag("Skill"))//Skillのコリジョン接触が起きた瞬間に床が落ちる
        {
            fall = true;
        }
    }


}
