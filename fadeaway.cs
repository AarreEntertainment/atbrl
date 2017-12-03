using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeaway : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<UnityEngine.UI.Text> ().color = new Color (GetComponent<UnityEngine.UI.Text> ().color.r, GetComponent<UnityEngine.UI.Text> ().color.g, GetComponent<UnityEngine.UI.Text> ().color.b, GetComponent<UnityEngine.UI.Text> ().color.a - Time.deltaTime/3);
	}
}
