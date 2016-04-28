using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableScript : MonoBehaviour
{

    Component halo;
    public bool FoodReward;
    bool selected = false;
    Text hoverText;
    GameObject makeSnack;
    GameObject cake;
    GameObject car;
    BaseAnimation anim;
	// Use this for initialization
	void Start () {
        halo = GetComponent("Halo");
        //
        hoverText = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<Text>();
        hoverText.text = "";
        makeSnack = GameObject.Find("/MakeSnack");
        cake = GameObject.Find("/Cake");
        car = GameObject.Find("/Car");
        anim = GameObject.Find("/Kid Container").GetComponent<BaseAnimation>();
    }


        public void hoverOn()
    {
        if (anim.isAnimated) return;    //don't activate
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null); //SetActive(true);
        selected = true;
        if (FoodReward)
        {   //food was chosen
            hoverText.text = "Push x to reward with cake";
        }
        else
        {   //nonfood was chosen
            hoverText.text = "Push x to reward with car";
        }
    }

    public void hoverOff()
    {
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        selected = false;
        hoverText.text = "";
    }

    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("z") && selected)
        {
            //
            hoverText.text = "";
            gameObject.SetActive(false);
            if (FoodReward)
            {   //food was chosen
                car.GetComponent<BoxCollider>().enabled = false;
                print("FOOD");  
            }
            else
            {   //nonfood was chosen
                cake.GetComponent<BoxCollider>().enabled = false;
                print("NON");
            }
            makeSnack.GetComponent<BoxCollider>().enabled = true;
        }
	
	}
}
