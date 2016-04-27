using UnityEngine;
using System.Collections;

public class AthleticTeenController : MonoBehaviour {

	public bool isAnimated;

	private Animator myAnimator;
	private float rotationSpeed;

	// Use this for initialization
	void Start () {

		rotationSpeed = 90.0f;
		myAnimator = GetComponent<Animator>();
		myAnimator.SetFloat ("walkspeed", 0.0f);

	}
	
	// Update is called once per frame
	void Update () {

		if (!isAnimated){
			SmoothRotate ();
		}
		//Rotate();

	}
		

	void SmoothRotate() {

		myAnimator.SetFloat ("walkspeed", 0.25f);

		Vector3 los = Camera.main.transform.position - transform.position;
		los = new Vector3(los.x, 0.0f, los.z);
		Quaternion losRotation = Quaternion.LookRotation (los);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, losRotation, rotationSpeed * Time.deltaTime);

		if (transform.rotation != losRotation) {
			myAnimator.SetFloat ("walkspeed", 0.25f);
		} else {
			myAnimator.SetFloat ("walkspeed", 0.0f);
		}

	}
}
