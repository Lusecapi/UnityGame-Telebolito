﻿using UnityEngine;
using System.Collections;

public class Limit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Brick") || other.tag.Equals("Wall"))
        {
            LevelManager.destroyBrickLine(other.transform.parent.gameObject);
            //Destroy(other.transform.parent.gameObject);
        }
    }
}
