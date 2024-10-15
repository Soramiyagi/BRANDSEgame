using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Player
{
    public string characterName = "DefaultCharacter";

    // スピードとジャンプ力、スキルのクールダウン時間を派生クラスで設定
    protected override float Speed { get; set; } = 2.0f; // スピード値
    protected override float JumpForce { get; set; } = 5.0f; // ジャンプ力
    protected override float Skill1CooldownTime { get; set; } = 4.0f; // スキル1のクールダウン
    protected override float Skill2CooldownTime { get; set; } = 9.0f; // スキル2のクールダウン

    // プレハブを生成するための変数
    public GameObject prefab; // プレハブの参照をインスペクタで設定
    private GameObject spawnedPrefab; // 生成されたプレハブの参照

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    // スキル1が押されている間の処理をオーバーライド
    protected override void Skill1Held()
    {

    }

    // スキル1を発動する処理をオーバーライド
    protected override void UseSkill1()
    {

    }

    // スキル2が押されている間の処理をオーバーライド
    protected override void Skill2Held()
    {

    }

    // スキル2を発動する処理をオーバーライド
    protected override void UseSkill2()
    {

    }

    // 1秒後にプレハブを削除するためのコルーチン
    private IEnumerator DestroyPrefabAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 指定した秒数待機
        if (spawnedPrefab != null)
        {
            Destroy(spawnedPrefab); // プレハブを削除
            
        }
    }
}



