using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    #region Block Declaration
    public Transform aBlock;
    public Transform bBlock;
    public Transform cBlock;
    public Transform dBlock;
    public Transform eBlock;
    public Transform fBlock;
    public Transform gBlock;
    public Transform hBlock;
    public Transform iBlock;
    public Transform jBlock;
    public Transform kBlock;
    public Transform lBlock;
    public Transform mBlock;
    public Transform nBlock;
    public Transform oBlock;
    public Transform pBlock;
    public Transform qBlock;
    public Transform rBlock;
    public Transform sBlock;
    public Transform tBlock;
    public Transform uBlock;
    public Transform vBlock;
    public Transform wBlock;
    public Transform xBlock;
    public Transform yBlock;
    public Transform zBlock;
    #endregion

    private Block[] BlockList;
    public Block[] activeBlock
    {
        get { return ActiveBlock; }
    }

    private Block[] ActiveBlock;
    
    void Awake()
    {
        Transform[] block = new Transform[26]
        {
            aBlock, bBlock, cBlock, dBlock, eBlock, fBlock, gBlock, hBlock, iBlock, jBlock,
            kBlock, lBlock, mBlock, nBlock, oBlock, pBlock, qBlock, rBlock, sBlock, tBlock,
            uBlock, vBlock, wBlock, xBlock, yBlock, zBlock
        };

        int[] blockValue = new int[26]
        {
            100, 150, 150, 100, 100, 150, 100, 150, 100, 250, 250, 100, 150, 100, 100, 150, 250, 100, 100, 100, 100, 150, 150, 250, 150, 250
        };

        BlockList = new Block[16];

        for (int i = 0; i < block.Length; i++)
        {
            BlockList[i] = new Block(blockValue[i], block[i]);
        }
    }

    public void Reset()
    {
        for (int i = 0; i < 16; i++)
        {
            InstantiateNew(i);
        }
    }

    public void InstantiateNew(int index)
    {
        int r = Random.Range(0, 26);
        ActiveBlock[index] = new Block(BlockList[r].Value, Instantiate(BlockList[r].Prefab, new Vector2((float)(-8.272 + (index % 4) * 1.25), (float)(-4.375 + Mathf.Floor(index / 4) * 1.25)), Quaternion.identity));
    }
}
