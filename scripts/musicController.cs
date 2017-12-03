using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameObject.FindGameObjectWithTag ("Enemy").GetComponent<routeCalculator> ().playerSpotted) {
			transform.GetChild (1).GetComponent<AudioLowPassFilter> ().cutoffFrequency = 100 * GameObject.FindGameObjectWithTag ("Player").GetComponent<visibility> ().totalVisibility;
			transform.GetChild (0).GetComponent<AudioLowPassFilter> ().cutoffFrequency = 5000 * GameObject.FindGameObjectWithTag ("Player").GetComponent<visibility> ().totalVisibility;
		} else {
			transform.GetChild (1).GetComponent<AudioLowPassFilter> ().cutoffFrequency = 5000;
		}
	}
}
