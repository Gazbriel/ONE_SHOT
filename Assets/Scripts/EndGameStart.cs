﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ShowDialogController>().StartDialog(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
