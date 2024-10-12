using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : Player
{
    public string characterName = "DefaultCharacter";

    // スピードとジャンプ力、スキルのクールダウン時間を派生クラスで設定
    protected override float Speed { get; set; } = 2.0f; // スピード値
    protected override float JumpForce { get; set; } = 5.0f; // ジャンプ力
    protected override float Skill1CooldownTime { get; set; } = 4.0f; // スキル1のクールダウン
    protected override float Skill2CooldownTime { get; set; } = 9.0f; // スキル2のクールダウン

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // スキル1が押されている間の処理をオーバーライド
    protected override void Skill1Held()
    {
        Debug.Log("Bomb is charging Skill 1!");
        // スキル1の内容をここに追加
    }

    // スキル2が押されている間の処理をオーバーライド
    protected override void Skill2Held()
    {
        Debug.Log("Bomb is charging Skill 2!");
        // スキル2の内容をここに追加
    }

    // スキル1をオーバーライド
    protected override void UseSkill1()
    {
        Debug.Log("Bomb used Skill 1");
        // スキル1の内容をここに追加
        base.UseSkill1(); // クールダウン処理
    }

    // スキル2をオーバーライドして特定の動作を実装
    protected override void UseSkill2()
    {
        Debug.Log("Bomb used Skill 2");
        // スキル2の内容をここに追加
        base.UseSkill2(); // クールダウン処理
    }
}
