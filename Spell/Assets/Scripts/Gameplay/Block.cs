using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Transform Prefab { get; set; }
    public int Value { get; set; }

    public Block(int value, Transform prefab)
    {
        Value = value;
        Prefab = prefab;
    }
}
