using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // スピードとジャンプ力をプロパティ化して派生クラスで設定可能に
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float jumpForce = 5.0f;

    protected bool isGrounded;
    protected Rigidbody rb;

    // スキル1とスキル2のクールダウン時間 (フィールドをシリアライズ)
    [SerializeField] private float skill1CooldownTime = 5.0f;
    [SerializeField] private float skill2CooldownTime = 7.0f;

    protected float moveHorizontal, moveVertical;

    //向きを出すためのもの
    private Vector3 pointA = new Vector3(0, 0, 0);
    private Vector3 pointB = new Vector3(0, 0, 0);
    protected float angle = 0;

    // プロパティでフィールドを操作
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

    // 移動処理
    protected virtual void FixedUpdate()
    {
        HandleMovement();

        //向き計算
        pointB = new Vector3(moveHorizontal, 0, moveVertical);
        // ベクトルの計算
        Vector3 direction = pointB - pointA;
        // 角度を計算
        angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg; // Z軸を使って角度を計算

        Quaternion targetRotation = Quaternion.Euler(0, -angle + 90, 0);
        this.transform.rotation = targetRotation;
    }

    // 移動メソッド
    protected void HandleMovement()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * Speed * Time.deltaTime, Space.World); // Speedを使用
    }

    // 左スティックや十字キーで移動
    public void OnMove(InputAction.CallbackContext Move)
    {
        Vector2 movementInput = Move.ReadValue<Vector2>();
        moveHorizontal = movementInput.x;
        moveVertical = movementInput.y;
    }

    // Jump処理
    public void OnJump(InputAction.CallbackContext Jump)
    {
        if (Jump.started && isGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse); // JumpForceを使用
            isGrounded = false;
        }
    }

    //Skill1処理
    public void OnSkill1(InputAction.CallbackContext Skill1)
    {
        if (Skill1.started && canUseSkill1 == true)
        {
            //押している間
            Skill1Held();
        }
        else if (Skill1.canceled)
        {
            //離した時
            UseSkill1();
        }
    }

    //Skill2処理
    public void OnSkill2(InputAction.CallbackContext Skill2)
    {
        if (Skill2.started && canUseSkill2 == true)
        {
            //押している間
            Skill2Held();
        }
        else if (Skill2.canceled)
        {
            //離した時
            UseSkill2();
        }
    }

    // スキル1が押されている間の処理
    protected virtual void Skill1Held()
    {
        
    }

    // スキル1を発動する処理
    protected virtual void UseSkill1()
    {
        canUseSkill1 = false;
    }

    // スキル2が押されている間の処理
    protected virtual void Skill2Held()
    {
        
    }

    // スキル2を発動する処理
    protected virtual void UseSkill2()
    {
        canUseSkill2 = false;
    }

    // スキル1のクールダウン処理
    protected virtual IEnumerator Skill1Cooldown()
    {
        yield return new WaitForSeconds(Skill1CooldownTime);
        canUseSkill1 = true;
        Debug.Log("Skill 1 ready!");
    }

    // スキル2のクールダウン処理
    protected virtual IEnumerator Skill2Cooldown()
    {
        yield return new WaitForSeconds(Skill2CooldownTime);
        canUseSkill2 = true;
        Debug.Log("Skill 2 ready!");
    }

    // 地面に接触したときに呼ばれる
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
