using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour {

    private float timerSpeed = 1.8f;
    public GameObject leftSpikes;
    public GameObject rightSpikes;

    GameObject[][] path;

    private void Awake()
    {
        
       
    }

    public void setup(float x)
    {
        //On the left side
        if(x < 4){
            leftSpikes.SetActive(true);
            InvokeRepeating("ShowAndHideRightSpike", timerSpeed, timerSpeed);
        }
        else
        {
            rightSpikes.SetActive(true);
            InvokeRepeating("ShowAndHideLeftSpike", timerSpeed, timerSpeed);
            
          
        }


      
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool active = false;
    private void ShowAndHideSpikes()
    {
        active = !active;
        rightSpikes.SetActive(active);

    }


    private void ShowAndHideRightSpike()
    {
        active = !active;
        rightSpikes.SetActive(active);
    }
    private void ShowAndHideLeftSpike()
    {
        active = !active;
        leftSpikes.SetActive(active);
    }
}
