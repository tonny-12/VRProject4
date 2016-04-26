using UnityEngine;
using System.Collections;

public class KidController : MonoBehaviour {

	public float wait;
	public float walk;
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
