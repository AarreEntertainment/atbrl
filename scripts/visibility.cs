using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visibility : MonoBehaviour {
	public float lightVisibility;
	public float distanceVisibility;
	public float soundVisibility;
	public float standVisibility;
	public float totalVisibility;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float mod = 0;
		if (Input.GetButton ("Fire1")||Input.GetButton("Fire2")) {
			mod = 0.5f;
		}
		soundVisibility = Mathf.Abs (Input.GetAxis ("Vertical")) * (1 - mod);
		standVisibility = 1f;
		if (Input.GetButton ("Fire2")) {
			standVisibility = 0.5f;
		}
		totalVisibility = (lightVisibility  + soundVisibility + standVisibility) / 4*distanceVisibility;
	}
}
