using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Human
{
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
