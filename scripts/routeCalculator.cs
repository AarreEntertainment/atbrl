using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class routeCalculator : MonoBehaviour {
	float findThreshold = 0.8f;
	public GameObject collectible;
	public GameObject looker;
	public bool goingToSpawn;
	public List <Transform> route;
	public List <Transform> lanterns;
	GameObject player;
	public bool lookforPlayer = false;
	public bool playerSpotted = false;
	public float playerSpotCounter = 10f;
	public float playerLoseCounter = 10f;
	public float difficulty = 1f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		lanterns = new List<Transform> ();
		route = new List<Transform> ();
		foreach (GameObject lantern in GameObject.FindGameObjectsWithTag("lantern")) {
			lanterns.Add (lantern.transform);
		}
	}
	void OnAnimatorIK(){
		GetComponent<Animator> ().SetLookAtWeight (1);
		if (!playerSpotted) {
			GetComponent<Animator> ().SetLookAtPosition (looker.transform.position);
		} else {
			GetComponent<Animator> ().SetLookAtPosition (player.transform.position);
		}
			
	}

	void sort(ref List<Transform> origList, Transform reference)
	{
		origList.Sort (delegate(Transform x, Transform y) {
			return Vector3.Distance (reference.position, x.position).CompareTo (Vector3.Distance (reference.position,y.position));
		});
	}

	void CalculateRoute(){
		if (route.Count > 0)
			route.RemoveRange(0, route.Count);
		List<Transform> routelist = new List<Transform> (lanterns);
		sort (ref routelist, transform);
		route.Add (routelist [0]);
		routelist.RemoveAt (0);
		while (routelist.Count > Random.Range(30,40)) {
			sort (ref routelist, route [route.Count - 1]);
			int index = Random.Range (0, 1);
			if (route.Count == 1)
				index = 0;
			route.Add (routelist [index]);
			routelist.RemoveAt (index);
		}
		setTarget(route [0]);
	}

	void setTarget(Transform target) {
		GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl> ().SetTarget (target);
	}

	void playerSpotCheck(){
		if (!playerSpotted) {
			if (player.GetComponent<visibility> ().totalVisibility > findThreshold) {
				route.RemoveRange (0, route.Count);
				lookforPlayer = true;
				setTarget (player.transform);
				playerSpotCounter = 0.4f;
			}
		}
		else{
			lookforPlayer = false;

			if (playerLoseCounter <= 0) {
				playerSpotted = false;
				lookforPlayer = true;
			} else {
				if (player.GetComponent<visibility> ().totalVisibility < 0.3f)
					playerLoseCounter -= Time.deltaTime;
			}
		}

		if (lookforPlayer) {
			if (playerSpotCounter <= 0f) {
				setTarget (null);
				GetComponent<NavMeshAgent> ().Stop ();
				looker.transform.parent.GetComponent<Animator> ().SetTrigger ("lookAround");
			} else {
				playerSpotCounter -= Time.deltaTime;
			}
		}
	}

	public void playerNotFound(){
		CalculateRoute ();
		lookforPlayer = false;
		GetComponent<NavMeshAgent> ().Resume ();
	}

	// Update is called once per frame
	void Update () {
		playerSpotCheck ();
		if (Vector3.Distance (transform.position, player.transform.position) < 50) {

			player.GetComponent<visibility> ().distanceVisibility = 1-Vector3.Distance (transform.position, player.transform.position) / 50;
		}
		if (!playerSpotted && !lookforPlayer) {

			if (lanterns != null && route.Count < 1) {
				CalculateRoute ();
			}

			if (Vector3.Distance (transform.position, route [0].position) < 3) {
				if (goingToSpawn) {
					Instantiate (collectible).transform.position=transform.position;
					findThreshold -= 0.05f;
					GetComponent<UnityEngine.AI.NavMeshAgent> ().speed += 0.1f;
					goingToSpawn = false;
				}
				route.RemoveAt (0);
				if(route.Count>0)
					setTarget (route [0]);
			}
		}
	}
}
