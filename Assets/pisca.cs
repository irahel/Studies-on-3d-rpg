﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisca : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;

        float emission = Mathf.PingPong(Time.time, 1.0f);
        Color baseColor = Color.green; //Replace this with whatever you want for your base color at emission level '1'
        //Color baseColor = Color.black; //Replace this with whatever you want for your base color at emission level '1'
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
       
        mat.SetColor("_EmissionColor", finalColor);
        
    }
}
