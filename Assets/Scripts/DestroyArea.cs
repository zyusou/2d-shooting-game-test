﻿using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D c)
    {
        Destroy(c.gameObject);
    }
}
