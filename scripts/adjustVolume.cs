using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<AudioSource> ().volume = GameObject.FindGameObjectWithTag ("Player").GetComponent<visibility> ().soundVisibility;
	}
}
