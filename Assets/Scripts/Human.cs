﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Human
{
    public int spawnTime;
    public HumanType humanType;
    public int spawner;
    public bool randomSpawner;
    public bool isSpawned;
}
public enum HumanType
{
    Human_Basic,
    Human_Chainsaw,
    Human_Safety,
    Human_Pyromaniac,
}
