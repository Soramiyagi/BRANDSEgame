using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] GameObject block, flyStone;

    public Vector2[] flyStonePos = new Vector2[4];  //浮遊石の座標(4つまで保存可能・(-1,-1)に設定することで無効化)

    public int blockWidth, blockHeight;
    public float blockInterval = 0;   //ブロック同士の幅


    // Start is called before the first frame update
    void Start()
    {
        //フィールドのブロックを配置
        for (int i = 0; i < blockHeight; i++)
        {
            for (int j = 0; j < blockWidth; j++)
            {
                Instantiate(block, new Vector3(blockInterval * i, 0, blockInterval * j), Quaternion.identity, this.transform).name = $"Block_{i}_{j}";
            }
        }

        //フィールドに浮遊石を配置
        for (int i = 0; i < 4; i++)
        {
            if (!(flyStonePos[i].x == -1 && flyStonePos[i].y == -1))
            {
                foreach (Transform child in this.transform)
                {
                    if (child.name == $"Block_{flyStonePos[i].x}_{flyStonePos[i].y}")
                    {
                        Destroy(child.gameObject);
                        Instantiate(flyStone, new Vector3(blockInterval * flyStonePos[i].x, 0.5f, blockInterval * flyStonePos[i].y), Quaternion.identity, this.transform).name = $"FlyStone_{flyStonePos[i].x}_{flyStonePos[i].y}";
                        break; // 最初に見つけたらループを抜ける
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    void FallCheck()
    {
    }
}
