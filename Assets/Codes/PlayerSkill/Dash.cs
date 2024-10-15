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

    public float forceAmount = 10f; // 加える力の大きさ(ダッシュの早さ)
    private bool skill1Flag = true;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    // スキル1が押されている間の処理をオーバーライド
    protected override void Skill1Held()
    {
        if (canUseSkill1 == true)
        {
            // 点Aの設定
            Vector3 pointA = new Vector3(0, 0, 0);

            // 点Bの設定
            Vector3 pointB = new Vector3(moveHorizontal, 0, moveVertical);

            // ベクトルの計算
            Vector3 direction = pointB - pointA;

            // 角度を計算
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg; // Z軸を使って角度を計算

            // 角度をラジアンに変換
            float radians = angle * Mathf.Deg2Rad;

            // 力のベクトルを計算
            Vector3 force = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians)) * forceAmount;

            // 指定した角度方向に力を加える
            rb.AddForce(force, ForceMode.Impulse);
            canUseSkill1 = false;
        }
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