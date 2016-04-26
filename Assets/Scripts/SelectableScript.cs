using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectableScript : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler
{

    Component halo;
    public bool FoodReward;
    bool selected = false;

	// Use this for initialization
	void Start () {
        halo = GetComponent("Halo");
       
	}


        public void OnPointerEnter(PointerEventData eventData)
    {
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null); //SetActive(true);
        selected = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        selected = false;
    }

    
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("z") && selected)
        {
            if (FoodReward)
            {   //food was chosen
                print("FOOD");  
            }
            else
            {   //nonfood was chosen
                print("NON");
            }
        }
	
	}
}
