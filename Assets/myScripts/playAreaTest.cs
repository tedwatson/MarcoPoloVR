using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class playAreaTest : MonoBehaviour {

    private SteamVR_PlayArea playArea;

	// Use this for initialization
	void Start () {
        playArea = GetComponent<SteamVR_PlayArea>();
        for (int i = 0; i < playArea.vertices.Length; i++)
        {
            print("element " + i + " is " + playArea.vertices[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
