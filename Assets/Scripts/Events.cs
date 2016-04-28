using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {

	public GameObject cake;
	public GameObject car;
	public GameObject snack;
	public GameObject makesnack;
	public GameObject book;

	public GameObject kid;
	public GameObject obeseTeen;
	public GameObject athleticTeen;
	public GameObject middleTeen;

	private Transform cakeTrans;
	private Transform carTrans;
	private Transform snackTrans;
	private Transform makesnackTrans;
	private Transform bookTrans;

	private Transform kidTrans;
	private Transform obeseTeenTrans;
	private Transform athleticTeenTrans;
	private Transform middleTeenTrans;


	// Use this for initialization
	void Start () {
		kidTrans = kid.GetComponent<Transform> ();
		cakeTrans = cake.GetComponent<Transform> ();
		carTrans = car.GetComponent<Transform> ();

		obeseTeenTrans = obeseTeen.GetComponent<Transform> ();
		athleticTeenTrans = athleticTeen.GetComponent<Transform> ();
		middleTeenTrans = middleTeen.GetComponent<Transform> ();

		snackTrans = snack.GetComponent<Transform> ();
		makesnackTrans = makesnack.GetComponent<Transform> ();
		bookTrans = book.GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update () {
		//float dist = Vector3.Distance (kidTrans.position, cakeTrans.position);

		//Debug.Log (dist.ToString ());
		Vector3 cakelos = kidTrans.position - cakeTrans.position;
		cakelos = new Vector3 (cakelos.x, 0.0f, cakelos.z);

		if (cakelos.magnitude < 0.4f){
			cake.SetActive (false);
		}

		Vector3 carlos = kidTrans.position - carTrans.position;
		carlos = new Vector3 (carlos.x, 0.0f, carlos.z);

		if (carlos.magnitude < 0.4f){
			car.SetActive (false);
		}

		//snack
		Vector3 obeseSnacklos = obeseTeenTrans.position - snackTrans.position;
		obeseSnacklos = new Vector3 (obeseSnacklos.x, 0.0f, obeseSnacklos.z);

		if (obeseSnacklos.magnitude < 0.4f){
			snack.SetActive (false);
		}

		Vector3 athSnacklos = athleticTeenTrans.position - snackTrans.position;
		athSnacklos = new Vector3 (athSnacklos.x, 0.0f, athSnacklos.z);

		if (athSnacklos.magnitude < 0.4f){
			snack.SetActive (false);
		}

		Vector3 midSnacklos = middleTeenTrans.position - snackTrans.position;
		midSnacklos = new Vector3 (midSnacklos.x, 0.0f, midSnacklos.z);

		if (midSnacklos.magnitude < 0.4f){
			snack.SetActive (false);
		}

		//book
		Vector3 obeseBooklos = obeseTeenTrans.position - bookTrans.position;
		obeseBooklos = new Vector3 (obeseBooklos.x, 0.0f, obeseBooklos.z);

		if (obeseBooklos.magnitude < 0.4f){
			book.SetActive (false);
		}

		Vector3 athBooklos = athleticTeenTrans.position - bookTrans.position;
		athBooklos = new Vector3 (athBooklos.x, 0.0f, athBooklos.z);

		if (athBooklos.magnitude < 0.4f){
			book.SetActive (false);
		}

		Vector3 midBooklos = middleTeenTrans.position - bookTrans.position;
		midBooklos = new Vector3 (midBooklos.x, 0.0f, midBooklos.z);

		if (midBooklos.magnitude < 0.4f){
			book.SetActive (false);
		}



	}
}
