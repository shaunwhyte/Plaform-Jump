using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Zone : MonoBehaviour
{


    public int startHeight;
    public int endHeight;

    public void setStartingAndEndingHeight(int start , int end)
    {
        this.startHeight = start; this.endHeight = end;
    }

    public abstract void contructZone();

    private List<Platform> platforms = new List<Platform>();

    public void addPlatform(Platform p)
    {
        platforms.Add(p);
    }

    public void removePlatform(Platform p)
    {
        platforms.Remove(p);
    }

    
}
