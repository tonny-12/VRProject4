using UnityEngine;
using System.Collections;

public class ObeseTeenController : MonoBehaviour {

	private Animator myAnimator;

	// Use this for initialization
	void Start () {
	
		myAnimator = GetComponent<Animator> ();
		myAnimator.SetFloat ("walkspeed", 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
