using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // �X�s�[�h�ƃW�����v�͂��v���p�e�B�����Ĕh���N���X�Őݒ�\��
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float jumpForce = 5.0f;

    protected bool isGrounded;
    protected Rigidbody rb;

    // �X�L��1�ƃX�L��2�̃N�[���_�E������ (�t�B�[���h���V���A���C�Y)
    [SerializeField] private float skill1CooldownTime = 5.0f;
    [SerializeField] private float skill2CooldownTime = 7.0f;

    private float moveHorizontal, moveVertical;

    // �v���p�e�B�Ńt�B�[���h�𑀍�
    protected virtual float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    protected virtual float JumpForce
    {
        get { return jumpForce; }
        set { jumpForce = value; }
    }
    protected virtual float Skill1CooldownTime
    {
        get { return skill1CooldownTime; }
        set { skill1CooldownTime = value; }
    }

    protected virtual float Skill2CooldownTime
    {
        get { return skill2CooldownTime; }
        set { skill2CooldownTime = value; }
    }

    protected bool canUseSkill1 = true;
    protected bool canUseSkill2 = true;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }

    // �ړ�����
    protected virtual void FixedUpdate()
    {
        HandleMovement();
    }

    // �ړ����\�b�h
    protected void HandleMovement()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * Speed * Time.deltaTime, Space.World); // Speed���g�p
    }

    // ���X�e�B�b�N��\���L�[�ňړ�
    public void OnMove(InputAction.CallbackContext Move)
    {
        Vector2 movementInput = Move.ReadValue<Vector2>();
        moveHorizontal = movementInput.x;
        moveVertical = movementInput.y;
    }

    // Jump����
    public void OnJump(InputAction.CallbackContext Jump)
    {
        if (Jump.started && isGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse); // JumpForce���g�p
            isGrounded = false;
        }
    }

    //Skill1����
    public void OnSkill1(InputAction.CallbackContext Skill1)
    {
        if (Skill1.performed)
        {
            //�����Ă����
            Skill1Held();
        }
        else if (Skill1.canceled)
        {
            //��������
            UseSkill1();
        }
    }

    //Skill2����
    public void OnSkill2(InputAction.CallbackContext Skill2)
    {
        if (Skill2.performed)
        {
            //�����Ă����
            Skill2Held();
        }
        else if (Skill2.canceled)
        {
            //��������
            UseSkill2();
        }
    }

    // �X�L��1��������Ă���Ԃ̏���
    protected virtual void Skill1Held()
    {
        
    }

    // �X�L��1�𔭓����鏈��
    protected virtual void UseSkill1()
    {
        
        canUseSkill1 = false;
        StartCoroutine(Skill1Cooldown());
    }

    // �X�L��2��������Ă���Ԃ̏���
    protected virtual void Skill2Held()
    {
        
    }

    // �X�L��2�𔭓����鏈��
    protected virtual void UseSkill2()
    {
        
        canUseSkill2 = false;
        StartCoroutine(Skill2Cooldown());
    }

    // �X�L��1�̃N�[���_�E������
    IEnumerator Skill1Cooldown()
    {
        yield return new WaitForSeconds(Skill1CooldownTime);
        canUseSkill1 = true;
        Debug.Log("Skill 1 ready!");
    }

    // �X�L��2�̃N�[���_�E������
    IEnumerator Skill2Cooldown()
    {
        yield return new WaitForSeconds(Skill2CooldownTime);
        canUseSkill2 = true;
        Debug.Log("Skill 2 ready!");
    }

    // �n�ʂɐڐG�����Ƃ��ɌĂ΂��
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
