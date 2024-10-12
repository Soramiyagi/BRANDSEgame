using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : Player
{
    public string characterName = "DefaultCharacter";

    // �X�s�[�h�ƃW�����v�́A�X�L���̃N�[���_�E�����Ԃ�h���N���X�Őݒ�
    protected override float Speed { get; set; } = 2.0f; // �X�s�[�h�l
    protected override float JumpForce { get; set; } = 5.0f; // �W�����v��
    protected override float Skill1CooldownTime { get; set; } = 4.0f; // �X�L��1�̃N�[���_�E��
    protected override float Skill2CooldownTime { get; set; } = 9.0f; // �X�L��2�̃N�[���_�E��

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // �X�L��1��������Ă���Ԃ̏������I�[�o�[���C�h
    protected override void Skill1Held()
    {
        Debug.Log("Bomb is charging Skill 1!");
        // �X�L��1�̓��e�������ɒǉ�
    }

    // �X�L��2��������Ă���Ԃ̏������I�[�o�[���C�h
    protected override void Skill2Held()
    {
        Debug.Log("Bomb is charging Skill 2!");
        // �X�L��2�̓��e�������ɒǉ�
    }

    // �X�L��1���I�[�o�[���C�h
    protected override void UseSkill1()
    {
        Debug.Log("Bomb used Skill 1");
        // �X�L��1�̓��e�������ɒǉ�
        base.UseSkill1(); // �N�[���_�E������
    }

    // �X�L��2���I�[�o�[���C�h���ē���̓��������
    protected override void UseSkill2()
    {
        Debug.Log("Bomb used Skill 2");
        // �X�L��2�̓��e�������ɒǉ�
        base.UseSkill2(); // �N�[���_�E������
    }
}
