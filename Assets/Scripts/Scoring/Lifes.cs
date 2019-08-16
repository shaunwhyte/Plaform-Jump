using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour {

    public GameObject heartObj;
    public GameObject camera;
    //Placed on the player.
    public int lifes = 3;
    List<GameObject> hearts = new List<GameObject>();
    // Use this for initialization
    void Start () {
        //Initial Other hearts;
        hearts.Add(heartObj);
          for(int i = 1; i < lifes; i++)
           {
            Debug.Log("Another one bites the dust " + (heartObj.GetComponent<RectTransform>().localPosition.y ) );
            GameObject newHeart = Instantiate(heartObj);
           newHeart.transform.parent = camera.transform;
            newHeart.GetComponent<RectTransform>().transform.localPosition = new Vector3(heartObj.GetComponent<RectTransform>().position.x + 1, heartObj.GetComponent<RectTransform>().localPosition.y, 0f);
            
            hearts.Add(newHeart);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
