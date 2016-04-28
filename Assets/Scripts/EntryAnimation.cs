using UnityEngine;
using System.Collections;

//Attach this script to a character to have it travel between
//a set of waypoints. waypoints is a gameobject that contains
//empty waypoint gameobjects, placed at the desired locations.
public class EntryAnimation : MonoBehaviour {
	

	public GameObject waypoints;

	private Animator myAnimator;
	private float rotationSpeed;

	Transform[] waypointList;
	private Transform currentTarget;
	private int targetIndex;


	// Use this for initialization
	void Start () {

		//set animation flag and turn on walking
		myAnimator = GetComponent<Animator>();
		myAnimator.SetFloat ("walkspeed", 1.0f);

		rotationSpeed = 90.0f;

		waypointList = waypoints.GetComponentsInChildren<Transform> ();

		targetIndex = 0;
		currentTarget = waypointList [targetIndex];

		gameObject.GetComponent<BaseAnimation> ().isAnimated = true;

		Debug.Log (waypointList[0].position.ToString ());

	}
	
	// Update is called once per frame
	void Update () {
		if(targetIndex < waypointList.Length){
			currentTarget = waypointList [targetIndex];
			
			Vector3 toPosition = currentTarget.position;

			Vector3 los = toPosition - transform.position;
			los = new Vector3 (los.x, 0.0f, los.z);
			if (los.magnitude < 0.5f){
				targetIndex += 1;


			}

			SmoothRotate (toPosition);

		} else {
			myAnimator.SetFloat ("walkspeed", 0.0f);
			gameObject.GetComponent<BaseAnimation> ().isAnimated = false;
		}
			
	}

	void SmoothRotate(Vector3 toPosition) {

		myAnimator.SetFloat ("walkspeed", 1.0f);

		Vector3 los = toPosition - transform.position;
		los = new Vector3 (los.x, 0.0f, los.z);
		Quaternion losRotation = Quaternion.LookRotation (los);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, losRotation, rotationSpeed * Time.deltaTime);
	}
}
