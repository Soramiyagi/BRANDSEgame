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

    public float forceAmount = 10f; // ������͂̑傫��(�_�b�V���̑���)
    private bool skill1Flag = true;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    // �X�L��1��������Ă���Ԃ̏������I�[�o�[���C�h
    protected override void Skill1Held()
    {
        if (canUseSkill1 == true)
        {
            // �_A�̐ݒ�
            Vector3 pointA = new Vector3(0, 0, 0);

            // �_B�̐ݒ�
            Vector3 pointB = new Vector3(moveHorizontal, 0, moveVertical);

            // �x�N�g���̌v�Z
            Vector3 direction = pointB - pointA;

            // �p�x���v�Z
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg; // Z�����g���Ċp�x���v�Z

            // �p�x�����W�A���ɕϊ�
            float radians = angle * Mathf.Deg2Rad;

            // �͂̃x�N�g�����v�Z
            Vector3 force = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians)) * forceAmount;

            // �w�肵���p�x�����ɗ͂�������
            rb.AddForce(force, ForceMode.Impulse);
            canUseSkill1 = false;
        }
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