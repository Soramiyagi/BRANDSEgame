using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] GameObject block, flyStone;

    public Vector2[] flyStonePos = new Vector2[4];  //���V�΂̍��W(4�܂ŕۑ��\�E(-1,-1)�ɐݒ肷�邱�ƂŖ�����)

    public int blockWidth, blockHeight;
    public float blockInterval = 0;   //�u���b�N���m�̕�


    // Start is called before the first frame update
    void Start()
    {
        //�t�B�[���h�̃u���b�N��z�u
        for (int i = 0; i < blockHeight; i++)
        {
            for (int j = 0; j < blockWidth; j++)
            {
                Instantiate(block, new Vector3(blockInterval * i, 0, blockInterval * j), Quaternion.identity, this.transform).name = $"Block_{i}_{j}";
            }
        }

        //�t�B�[���h�ɕ��V�΂�z�u
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
                        break; // �ŏ��Ɍ������烋�[�v�𔲂���
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
