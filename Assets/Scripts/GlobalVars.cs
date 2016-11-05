using UnityEngine;
using System.Collections;

public class GlobalVars
{
    private static GlobalVars sInstance;
    public static GlobalVars Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new GlobalVars();
            }
            return sInstance;
        }
    }

    private int playerHP = 3;
    public int PlayerHP
    {
        get { return playerHP; }
        set { playerHP = value; }
    }

    private int childCount = 0;
    public int ChildCount
    {
        get { return childCount; }
        set { childCount = value; }
    }

    private int childMax = 5;
    public int ChildMax
    {
        get { return childMax; }
        set { childMax = value; }
    }
}
