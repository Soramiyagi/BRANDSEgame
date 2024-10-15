using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Player
{
    public string characterName = "DefaultCharacter";

    // �X�s�[�h�ƃW�����v�́A�X�L���̃N�[���_�E�����Ԃ�h���N���X�Őݒ�
    protected override float Speed { get; set; } = 2.0f; // �X�s�[�h�l
    protected override float JumpForce { get; set; } = 5.0f; // �W�����v��
    protected override float Skill1CooldownTime { get; set; } = 4.0f; // �X�L��1�̃N�[���_�E��
    protected override float Skill2CooldownTime { get; set; } = 9.0f; // �X�L��2�̃N�[���_�E��

    // �v���n�u�𐶐����邽�߂̕ϐ�
    public GameObject prefab; // �v���n�u�̎Q�Ƃ��C���X�y�N�^�Őݒ�
    private GameObject spawnedPrefab; // �������ꂽ�v���n�u�̎Q��

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    // �X�L��1��������Ă���Ԃ̏������I�[�o�[���C�h
    protected override void Skill1Held()
    {

    }

    // �X�L��1�𔭓����鏈�����I�[�o�[���C�h
    protected override void UseSkill1()
    {

    }

    // �X�L��2��������Ă���Ԃ̏������I�[�o�[���C�h
    protected override void Skill2Held()
    {

    }

    // �X�L��2�𔭓����鏈�����I�[�o�[���C�h
    protected override void UseSkill2()
    {

    }

    // 1�b��Ƀv���n�u���폜���邽�߂̃R���[�`��
    private IEnumerator DestroyPrefabAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // �w�肵���b���ҋ@
        if (spawnedPrefab != null)
        {
            Destroy(spawnedPrefab); // �v���n�u���폜
            
        }
    }
}



