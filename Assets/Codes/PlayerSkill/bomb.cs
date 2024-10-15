using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Player
{
    public string characterName = "DefaultCharacter";

    // �X�s�[�h�ƃW�����v�́A�X�L���̃N�[���_�E�����Ԃ�h���N���X�Őݒ�
    protected override float Speed { get; set; } = 2.0f; // �X�s�[�h�l
    protected override float JumpForce { get; set; } = 5.0f; // �W�����v��
    protected override float Skill1CooldownTime { get; set; } = 4.0f; // �X�L��1�̃N�[���_�E��
    protected override float Skill2CooldownTime { get; set; } = 9.0f; // �X�L��2�̃N�[���_�E��

    // �v���n�u�𐶐����邽�߂̕ϐ�
    public GameObject skill1Prehub; // �X�L��1�̃v���n�u
    public GameObject skill2Prehub; // �X�L��2�̃v���n�u
    private GameObject spawnedPrefab; // �������ꂽ�v���n�u�̎Q��

    private bool previewSkill1 = false; // skill1�̃v���r���[�̂��߂̃t���O

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Debug.Log(moveHorizontal);

        if (previewSkill1 && spawnedPrefab != null)
        {
            // �v���C���[�̈ʒu�ɒǏ] (Y����-0.5���ăv���C���[�̉��ɒu��)
            Vector3 followPosition = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z + 4);
            spawnedPrefab.transform.position = followPosition;
            Debug.Log("Skill1 prefab is following the player.");

        }
    }

    protected override void Skill1Held()
    {
        previewSkill1 = true;
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        spawnedPrefab = Instantiate(skill1Prehub, spawnPosition, Quaternion.identity);

        // �R���W�������I�t�ɂ��鏈��
        Collider prefabCollider = spawnedPrefab.GetComponent<Collider>();
        if (prefabCollider != null)
        {
            prefabCollider.enabled = false; // �R���W�������I�t��
        }
    }

    protected override void UseSkill1()
    {
        previewSkill1 = false;
        if (spawnedPrefab != null)
        {
            // �v���n�u�����̈ʒu�ɌŒ肵�A�R���W�������I���ɂ���
            Collider prefabCollider = spawnedPrefab.GetComponent<Collider>();
            if (prefabCollider != null)
            {
                prefabCollider.enabled = true; // �R���W�������I����
            }

            // �v���n�u���폜���鏈��
            StartCoroutine(DestroyPrefabAfterDelay(0.1f));
        }
        base.UseSkill1(); // �N�[���_�E������
    }

    // �X�L��2��������Ă���Ԃ̏������I�[�o�[���C�h
    protected override void Skill2Held()
    {
        if (spawnedPrefab == null)
        {
            // �v���C���[�̈ʒu����Y����-0.5�����ʒu�Ƀv���n�u�𐶐�
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            spawnedPrefab = Instantiate(skill2Prehub, spawnPosition, Quaternion.identity);

            // �R���W�������I�t�ɂ��鏈��
            Collider prefabCollider = spawnedPrefab.GetComponent<Collider>();
            if (prefabCollider != null)
            {
                prefabCollider.enabled = false; // �R���W�������I�t��
            }

            Debug.Log("Bomb is charging Skill 2! Prefab instantiated at adjusted position.");
        }
        else
        {
            // �v���C���[�̈ʒu�ɒǏ]������ (Y����-0.5���ăv���C���[�̉��ɒu��)
            Vector3 followPosition = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            spawnedPrefab.transform.position = followPosition;
            Debug.Log("Prefab is following the player.");
        }
    }

    // �X�L��2�𔭓����鏈�����I�[�o�[���C�h
    protected override void UseSkill2()
    {
        if (spawnedPrefab != null)
        {
            // �v���n�u�����̈ʒu�ɌŒ肵�A�R���W�������I���ɂ���
            Collider prefabCollider = spawnedPrefab.GetComponent<Collider>();
            if (prefabCollider != null)
            {
                prefabCollider.enabled = true; // �R���W�������I����
            }

            // �v���n�u���폜���鏈��
            StartCoroutine(DestroyPrefabAfterDelay(0.1f));
        }

        base.UseSkill2(); // �N�[���_�E������
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


