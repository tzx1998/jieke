﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatcamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(Vector3.up * 180f);
	}
}
