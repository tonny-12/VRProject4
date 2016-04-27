using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    //private bool title = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //if any key is pressed
        if(Input.anyKeyDown)
        {
            //switch scene to main scene
            SceneManager.LoadScene("RoomSceneMod");
        }
	
	}
}
