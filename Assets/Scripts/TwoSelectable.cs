using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TwoSelectable : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler
{

    Component halo;
    public bool FoodReward;
    bool selected = false;
    Text hoverText;
    GameObject snack;
    GameObject book;
    BaseAnimation anim;
    // Use this for initialization
    void Start()
    {
        halo = GetComponent("Halo");
        //
        hoverText = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<Text>();
        hoverText.text = "";
        snack = GameObject.Find("/Snack");
        book = GameObject.Find("/Book");
        anim = GameObject.Find("/Kid Container").GetComponent<BaseAnimation>();

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (anim.isAnimated) return;    //don't activate
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null); //SetActive(true);
        selected = true;
        if (FoodReward)
        {   //food was chosen
            hoverText.text = "Make child eat snack";
        }
        else
        {   //nonfood was chosen
            hoverText.text = "Have child read instead";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        selected = false;
        hoverText.text = "";
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") && selected)
        {
            //
            gameObject.SetActive(false);
            if (FoodReward)
            {   //food was chosen
                print("SNACK");
                book.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {   //nonfood was chosen
                print("BOOK");
                snack.GetComponent<BoxCollider>().enabled = false;
            }

        }

    }
}
