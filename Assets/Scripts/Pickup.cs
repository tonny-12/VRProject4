using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	GameObject mainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;
	public float offset;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");


	}

	// Update is called once per frame
	void Update () {
		if(carrying){
			Carry (carriedObject);
			CheckDrop ();

		} else {
			PickupObject ();
		}
	}

	void Carry(GameObject obj){
		obj.GetComponent<Rigidbody>().useGravity = false;
		obj.transform.position = Vector3.Lerp(obj.transform.position,mainCamera.transform.position+ mainCamera.transform.forward * distance+mainCamera.transform.up*offset, Time.deltaTime*smooth);

	}

	void PickupObject(){
		if(Input.GetButtonDown("Fire1")){
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				isPickup p = hit.collider.GetComponent<isPickup> ();
				if(p!= null) {
					carrying = true;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
			}
		}
	}

	void CheckDrop(){
		if (Input.GetButtonDown("Fire1")){
			DropObject ();
		}
	}

	void DropObject(){
		carrying = false;
		carriedObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject = null;
	}
}
