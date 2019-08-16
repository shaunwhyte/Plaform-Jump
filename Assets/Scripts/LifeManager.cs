using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {

    public int lifes = 3;

    public GameObject lifeOne;
    public GameObject lifeTwo;
    public GameObject lifeThree;

    public Player player;

    public Sprite halfLife;
    public Sprite fullLife;

    public void takeLife()
    {
        lifes--;

        if(lifes == 2)
        {
            Debug.Log("Removing 3");
            swapSprite(lifeThree);
        }
        if (lifes == 1)
        {
            Debug.Log("Removing 2");
            swapSprite(lifeTwo);
        }
        if (lifes == 0)
        {
            Debug.Log("Removing 1");
            swapSprite(lifeOne);
            player.kill();
        }

       
    }

    public void swapSprite(GameObject life)
    {
        SpriteRenderer renderer = life.GetComponent<SpriteRenderer>();
        renderer.sprite = halfLife;
        
    }

    public void giveLife()
    {
        if(lifes > 3){
            Debug.LogError("To many lifes!");
        }
        lifes++;

        if (lifes == 3)
        {
            swapSpriteToAlive(lifeThree);
        }
        if (lifes == 2)
        {
            swapSpriteToAlive(lifeTwo);
        }

        if (lifes == 1)
        {
            swapSpriteToAlive(lifeOne);
        }
    }

    public void swapSpriteToAlive(GameObject life)
    {
        SpriteRenderer renderer = life.GetComponent<SpriteRenderer>();
        renderer.sprite = fullLife;

    }

}
