using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level  {

    public int level;
    public int maxExp;
    public string levelDes;

    public Level(int level, int maxExp, string levelDes)
    {
        this.level = level;
        this.maxExp = maxExp;
        this.levelDes = levelDes;
    }
}
