using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyZone : Zone {

    float speed = 2f;

    public GameObject usualPlatform;


    public override void contructZone()
    {
        usualPlatform = GameObject.Find("Platform");
        for (float i = this.startHeight; i < this.endHeight; i++)
        {
            GameObject g = getNewPlank(-18, i);
            i += (g.transform.position.y - i) + 2;
        }
    }

    GameObject getNewPlank(int generalX, float generalY)
    {
        GameObject newPlank = Instantiate(usualPlatform);
        float x = Random.Range(generalX, generalX + 30f);  // creates a number between 1 and 12
        float y = Random.Range(generalY, generalY + 2.5f);   // creates a number between 1 and 6
        newPlank.transform.position = new Vector3((float)(x), (float)(y), 0f);
        return newPlank;

    }
}
