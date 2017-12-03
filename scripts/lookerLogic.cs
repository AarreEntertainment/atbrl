using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookerLogic : MonoBehaviour {

	public Transform target;

	void OnTriggerEnter(Collider col){
		if(col.tag=="Player"){
			transform.parent.GetComponent<Animator> ().SetTrigger ("spotted");
			GameObject.FindGameObjectWithTag ("Enemy").GetComponent<routeCalculator> ().playerSpotted = true;
			GameObject.FindGameObjectWithTag ("Enemy").GetComponent<routeCalculator> ().playerLoseCounter = 5f;
		}
	}
	void Start(){
		transform.parent.SetParent (target, false);
	}


	private void FixedUpdate()
	{
		//transform.position = target.position + offset;
	}
}
