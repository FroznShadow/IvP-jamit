﻿using UnityEngine;
using System.Collections;

public class Exittokeittiö : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void exit()
    {
        Application.LoadLevel("Keittiö");
    }
}
