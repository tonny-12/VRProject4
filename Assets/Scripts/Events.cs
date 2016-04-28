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
    
	public bool givenCake;
	public bool givenCar;
	public bool kidExited;
	public bool inKitchen;

	public bool givenBook;
	public bool givenSnack;


    public bool teenEntered;
    public bool teenGo;

    bool resultScene;
    TextBoxManager textScript;
    GameObject trans;


	// Use this for initialization
	void Start () {
        trans = GameObject.Find("/FPSController.CardboardMain/Head/Main Camera/Canvas/Transition");
        trans.SetActive(false);
		givenCake = false;
        resultScene = false;
        teenEntered = false;
        teenGo = false;
        textScript = GameObject.Find("FPSController").GetComponent<TextBoxManager>();
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
        if(resultScene)
        {

            //grown kid entry
            if (givenCake && givenSnack && kid.GetComponent<BaseAnimation>().isAnimated == false && teenEntered == false)
            {
                teenEntered = true;
                obeseTeen.SetActive(true);

            }

            if (givenCake && givenBook && kid.GetComponent<BaseAnimation>().isAnimated == false && teenEntered == false)
            {
                teenEntered = true;
                middleTeen.SetActive(true);
                middleTeen.GetComponent<EntryAnimation>().enabled = !middleTeen.GetComponent<EntryAnimation>().enabled;
            }

            if (givenCar && givenBook && kid.GetComponent<BaseAnimation>().isAnimated == false && teenEntered == false)
            {
                teenEntered = true;
                athleticTeen.SetActive(true);

            }

            if (givenCar && givenSnack && kid.GetComponent<BaseAnimation>().isAnimated == false && teenEntered == false)
            {
                teenEntered = true;
                middleTeen.SetActive(true);

            }
        }

        if((givenCake || givenCar ) && !textScript.isActive)
        {

            kid.GetComponent<EntryAnimation>().enabled = false; // !kid.GetComponent<EntryAnimation>().enabled;
            kid.GetComponent<KitchenAnimation>().enabled = true; // !kid.GetComponent<KitchenAnimation>().enabled;
            snack.SetActive(true);
            book.SetActive(true);
            textScript.waiting = true;

        }
        if ((givenSnack || givenBook) && !textScript.isActive)
        {

            kid.GetComponent<KitchenAnimation>().enabled = false; //!kid.GetComponent<KitchenAnimation>().enabled;
            kid.GetComponent<ExitAnimation>().enabled = true; //!kid.GetComponent<ExitAnimation>().enabled;
            //transition
            trans.SetActive(true);
            if (Input.anyKeyDown)
            {
                trans.SetActive(false);
                resultScene = true;
            }
         

        }


        Vector3 cakelos = kidTrans.position - cakeTrans.position;
        cakelos = new Vector3(cakelos.x, 0.0f, cakelos.z);


        if (cakelos.magnitude < 0.4f){
			if (givenCake == false) {
				cake.SetActive (false);
                car.GetComponent<BoxCollider>().enabled = false;
                textScript.currentLine = 7;
                textScript.endAtLine = 10;
                textScript.EnableTextBox();

                car.GetComponent<BoxCollider>().enabled = false;

				givenCake = true;

			}
		}

		Vector3 carlos = kidTrans.position - carTrans.position;
		carlos = new Vector3 (carlos.x, 0.0f, carlos.z);

		if (carlos.magnitude < 0.4f){
			if (givenCar == false)
            {
                car.SetActive(false);
                cake.GetComponent<BoxCollider>().enabled = false;
                textScript.currentLine = 3;
                textScript.endAtLine = 6;
                textScript.EnableTextBox();

                cake.GetComponent<BoxCollider>().enabled = false;

                givenCar = true;
            }
		}

		//snack
		Vector3 snacklos = kidTrans.position - snackTrans.position;
		snacklos = new Vector3 (snacklos.x, 0.0f, snacklos.z);

		if (snacklos.magnitude < 0.4f){
			if (givenSnack == false) {
				snack.SetActive (false);
				book.SetActive (false);

                textScript.currentLine = 16;
                textScript.endAtLine = 17;
                textScript.EnableTextBox();

                givenSnack = true;

			}
		}

        //book
        Vector3 booklos = kidTrans.position - snackTrans.position;
        snacklos = new Vector3(booklos.x, 0.0f, booklos.z);

        if (booklos.magnitude < 0.4f)
        {
            if (givenBook == false)
            {
                book.SetActive(false);
                snack.SetActive(false);

                textScript.currentLine = 18;
                textScript.endAtLine = 19;
                textScript.EnableTextBox();


                givenBook = true;

            }
        }

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



        Vector3 obeselos = kidTrans.position - obeseTeenTrans.position;
        obeselos = new Vector3(obeselos.x, 0.0f, obeselos.z);
        if (obeselos.magnitude < 2.0f && teenGo == false)
        {
            obeseTeen.GetComponent<EntryAnimation>().enabled = !obeseTeen.GetComponent<EntryAnimation>().enabled;
            teenGo = true;
        }

        Vector3 middlelos = kidTrans.position - middleTeenTrans.position;
        middlelos = new Vector3(middlelos.x, 0.0f, middlelos.z);
        if (middlelos.magnitude < 2.0f && teenGo == false)
        {
            middleTeen.GetComponent<EntryAnimation>().enabled = !middleTeen.GetComponent<EntryAnimation>().enabled;
            teenGo = true;
        }

        Vector3 athleticlos = kidTrans.position - athleticTeenTrans.position;
        athleticlos = new Vector3(athleticlos.x, 0.0f, athleticlos.z);
        if (athleticlos.magnitude < 2.0f && teenGo == false)
        {
            athleticTeen.GetComponent<EntryAnimation>().enabled = !athleticTeen.GetComponent<EntryAnimation>().enabled;
            teenGo = true;
        }

    }
}
