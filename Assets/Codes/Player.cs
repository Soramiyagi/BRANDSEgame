using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;

    private float moveHorizontal, moveVertical;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }


    // ���X�e�B�b�N��WASD��Vector2���󂯎��܂�
    public void OnMove(InputAction.CallbackContext Move)
    {
        Vector2 movementInput = Move.ReadValue<Vector2>();
        moveHorizontal = movementInput.x;
        moveVertical = movementInput.y;
    }

    // Skill1�{�^���������ꂽ�Ƃ��̏���
    public void OnSkill1(InputAction.CallbackContext Skill1)
    {
        if (Skill1.started)
        {
            Debug.Log("Skill1");
        }
    }


    // Skill2�{�^���������ꂽ�Ƃ��̏���
    public void OnSkill2(InputAction.CallbackContext Skill2)
    {
        if (Skill2.started)
        {
            Debug.Log("Skill2");
        }
    }

    // Jump�{�^���������ꂽ�Ƃ��̏���
    public void OnJump(InputAction.CallbackContext Jump)
    {
        if (Jump.started)
        {
            Debug.Log("Jump");
        }
    }
}