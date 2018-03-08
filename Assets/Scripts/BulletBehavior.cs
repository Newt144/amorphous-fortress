using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    public float dmg = 1;
    public int timeAlive = 20;

    public bool isEnemyShot = false;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeAlive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
