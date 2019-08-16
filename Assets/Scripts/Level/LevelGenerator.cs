using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Sprite plankSprite;
    public GameObject typicalPlank;
    // Use this for initialization

    public int maxHeight = 100;

    void Start () {

        Zone easyZone = new EasyZone();
        easyZone.setStartingAndEndingHeight(0, 80);
        easyZone.contructZone();

        Zone spikeyZone = new SpikeyZone();
        spikeyZone.setStartingAndEndingHeight(85, 180);
        spikeyZone.contructZone();

         Zone fireZone = new MovingFireZoneSLow();
         fireZone.setStartingAndEndingHeight(190, 280);
         fireZone.contructZone();

        Zone spikeyZone2 = new SpikeyZone();
        spikeyZone2.setStartingAndEndingHeight(285, 400);
        spikeyZone2.contructZone();


    }



}
