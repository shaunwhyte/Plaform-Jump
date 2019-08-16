using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject toFollow;
    public float followSpeed = 1f;
    public float followOffset = 0;
    // Use this for initialization
    public float maxHeight = 0;
    Player player;
	void Start () {
        player = toFollow.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if(player.transform.position.y > maxHeight)
        {
            maxHeight = player.transform.position.y;
        }
        //Stops the camera from following the player down, unless he goes back up... 
        //Y speed alternates between a positive number wen going up and a negative number when going down.
        //www.youtube.com/watch?v=iJyPIBomFYQ
        if (player.ySpeed >= followOffset && player.transform.position.y > 12 )
        {
            Vector3 positionToFollow = new Vector3(transform.position.x, toFollow.transform.position.y, transform.position.z);
            if(positionToFollow.y < maxHeight)
            {
                return;
            }
            transform.position = Vector3.Lerp(transform.position, positionToFollow, followSpeed * Time.deltaTime);
        }
        if(player.transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y)
        {
            player.kill();
        }
        

    }
  
}
