using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool fall;       //�u���b�N��������t���O
    float fallSpeed;    //�u���b�N�̗����鑬��

    bool countDown;     //�u���b�N��������܂ł̃J�E���g���J�n����t���O
    float time;         //�u���b�N��������܂ł̎���


    Vector3 startPos;   //���̃u���b�N�̏����ʒu
    Vector3 currentPos; //���̃u���b�N�̌��݈ʒu

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
        

        //�u���b�N����
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
        if (collision.gameObject.CompareTag("Player"))//Player�����ɐڐG����ƈ�莞�Ԍo�ߌ�ɏ���������
        {
            countDown = true;
        }
        if (collision.gameObject.CompareTag("Skill"))//Skill�̃R���W�����ڐG���N�����u�Ԃɏ���������
        {
            fall = true;
        }
    }


}
