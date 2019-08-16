using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeyZone : Zone
{
   

    public GameObject spikeyPlatform;

    public override void contructZone()
    {
        spikeyPlatform = GameObject.Find("SpikePlatform");
        for(int i = this.startHeight; i < this.endHeight; i++)
        {
            getNewPlank(-18 , i);
            i += 6;
        }
    }

    GameObject getNewPlank(int generalX, float generalY)
    {
        GameObject newPlank = Instantiate(spikeyPlatform);
        float x = Random.Range(generalX, generalX + 30f);  // creates a number between 1 and 12
        float y = Random.Range(generalY, generalY + 4.5f);   // creates a number between 1 and 6
        newPlank.transform.position = new Vector3((float)(x), (float)(y), 0f);
        spikeyPlatform = GameObject.Find("SpikePlatform");
        newPlank.GetComponent<SpikeScript>().setup(x);
        return newPlank;

    }
}
