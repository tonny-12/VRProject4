using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OneSelectable : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler
{

    Component halo;
    bool selected = false;
    Text hoverText;
    GameObject snack;
    GameObject book;
    // Use this for initialization
    void Start()
    {
        halo = GetComponent("Halo");
        //
        hoverText = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<Text>();
        hoverText.text = "";
        snack = GameObject.Find("/Snack");
        book = GameObject.Find("/Book");
        snack.SetActive(false);
        book.SetActive(false);

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null); //SetActive(true);
        selected = true;
        hoverText.text = "Make snack for child";
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
            hoverText.text = "";
            snack.SetActive(true);
            book.SetActive(true);
            gameObject.SetActive(false);

        }

    }
}
