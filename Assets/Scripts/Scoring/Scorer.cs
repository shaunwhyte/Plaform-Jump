using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Placed on Player atm
public class Scorer : MonoBehaviour {

    public GameObject playerGameObject;
    public Text scoreText;

    public float maxScore = 0;
	// Use this for initialization
	void Start () {
   
    }
	
	// Update is called once per frame
	void Update () {
        if(playerGameObject != null)
        {
            if (maxScore < playerGameObject.transform.position.y)
            {
                maxScore = (int)playerGameObject.transform.position.y;
            }
            scoreText.text = "" + maxScore;
        }
        
	}
}
