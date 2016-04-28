using UnityEngine;
using System.Collections;

public class RaycastSelect : MonoBehaviour
{
    GameObject mainCamera;
    bool carrying = false;
    GameObject carriedObject;
    Ray ray;
    Ray checkRay;
    public float distance;
    public float smooth;
    public float offset;
    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");


    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
            //Carry(carriedObject);
            CheckDrop();

        }
        else
        {
            PickupObject();
        }
    }

    void Carry(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.transform.position = Vector3.Lerp(obj.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance + mainCamera.transform.up * offset, Time.deltaTime * smooth);

    }

    void PickupObject()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            SelectableScript p = hit.collider.GetComponent<SelectableScript>();
            if (p != null)
            {
                carrying = true;
                carriedObject = p.gameObject;
                p.hoverOn();
                //
            }
        } /*
        if (Input.GetButtonDown("Fire1"))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                SelectableScript p = hit.collider.GetComponent<SelectableScript>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                }
            }
        } */
    }

    void CheckDrop()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        checkRay = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hitCheck;
        if (Physics.Raycast(ray, out hitCheck))
        {
            SelectableScript p = hitCheck.collider.GetComponent<SelectableScript>();
            GameObject pCheck = p.gameObject;
            if (pCheck != carriedObject)
            {
                DropObject();
                
            }
        }
    }

    void DropObject()
    {
        carriedObject.GetComponent<SelectableScript>().hoverOff();
        carrying = false;
        carriedObject = null;
    }
}
