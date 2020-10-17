using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Human
{
    public int spawnTime;
    public HumanType humanType;
}
public enum HumanType
{
    Human_Basic,
    Human_Placeholder,
    Human_Placeholder2,
}
