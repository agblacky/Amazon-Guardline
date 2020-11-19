using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Human : MonoBehaviour
{
    public int spawnTime;
    public HumanType humanType;
    public bool isSpawned;
}


public enum HumanType
{
    Human_Basic,
    Human_Chainsaw,
    Human_Safety,
    Human_Pyromaniac,
}
