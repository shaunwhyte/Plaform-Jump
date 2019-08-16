using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {


    public GameObject start;
    public GameObject end;

    public GameObject player;

    public float speed;
    // Use this for initialization
    Vector3 nextPos;

    public bool move = false;


    void Start () {
        nextPos = end.transform.position;
    }

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform child2 in child.gameObject.transform)
            {
                if (child2.gameObject.tag == "fire")
                {
                    child2.gameObject.SetActive(false);
                }
            }
           
            if (child.gameObject.tag == "fire")
            {
                child.gameObject.SetActive(false);
            }

        }
    }

    // Update is called once per frame
    void Update () {

        if(!move && player.transform.position.y > start.transform.position.y)
        {
            move = true;
            foreach (Transform child in transform)
            {
                foreach (Transform child2 in child.gameObject.transform)
                {
                    if (child2.gameObject.tag == "fire")
                    {
                        child2.gameObject.SetActive(true);
                    }
                }

                if (child.gameObject.tag == "fire")
                {
                    child.gameObject.SetActive(true);
                }

            }
        }
        if (move)
        {
            float dis = Vector2.Distance(transform.position, end.transform.position); // Calculating Distance
            if (dis <= 0.3) // checking if distance is less than required distance.
            {
                nextPos = start.transform.position;
            }
            dis = Vector3.Distance(transform.position, start.transform.position); // Calculating Distance
            if (dis <= 0.3) // checking if distance is less than required distance.
            {
                nextPos = end.transform.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }    
        
       
    }
}
