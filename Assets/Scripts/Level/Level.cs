using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : BaseMono
{
    [SerializeField] protected int levelMax = 99;
    [SerializeField] protected int level = 0;

    protected virtual void LevelUp()
    {
        level++;
        this.LimitLevel();
    }
    protected virtual void SetLevel(int level)
    {
        this.level = level;
        this.LimitLevel();
    }
    protected virtual void LimitLevel()
    {
        if (level > levelMax) level = levelMax;
        if (level <= 0) level = 0;
    }
}