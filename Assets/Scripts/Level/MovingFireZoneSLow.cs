using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFireZoneSLow : Zone
{

    float speed = 2f;

    public GameObject usualPlatform;
    public GameObject firePlatform;
    public GameObject freeHeart;


    public override void contructZone()
    {
        usualPlatform = GameObject.Find("Platform");
        firePlatform = GameObject.Find("FirePlatformConstruct");
        freeHeart = GameObject.Find("FreeHeart");
        firePlatform = getFirePlatform(-4, this.startHeight);
        GameObject endPoint = firePlatform.GetComponentInChildren<FirePlatformEndPoint>().gameObject;
        endPoint.transform.position = new Vector3(endPoint.transform.position.x, this.endHeight,0);

        Debug.Log(usualPlatform == null);
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


    GameObject getFirePlatform(int x, float y)
    {
        GameObject newPlank = Instantiate(firePlatform);
        GameObject freeHeart = Instantiate(this.freeHeart);
        newPlank.transform.position = new Vector3((float)(x), (float)(y), 0f);
        freeHeart.transform.position = new Vector3((float)(x-4), (float)(y-2.5), 0f);
        return newPlank;

    }


}
