using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;
	public TextAsset textFile;
	public string[] textLines;
	public int currentLine;
	public int endAtLine;
	public bool isActive;
	public bool stopPlayerMovement;
	public FirstPersonController player;
	public SelectableScript choice1;

	private bool isTyping = false;
	private bool cancelTyping = false;
	public float typeSpeed;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<FirstPersonController> ();
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}
		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (!isActive) {
			return;
		}
		//theText.text = textLines [currentLine];
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetButtonDown("PS4_Circle")) {
			if (!isTyping) {
				currentLine += 1;
				if (currentLine > endAtLine) {
					DisableTextBox ();
				} else {
					StartCoroutine (TextScroll (textLines [currentLine]));
				}	
			} else if (isTyping && !cancelTyping) {
				cancelTyping = true;
			}
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Kid Container") {
			currentLine = 0;
			endAtLine = 1;
			EnableTextBox ();
		} else if (other.gameObject.name == "Obese Teen Container") {
			currentLine = 6;
			endAtLine = 7;
			EnableTextBox ();
		} else if (other.gameObject.name == "Middleweight Container 1") {
			currentLine = 8;
			endAtLine = 9;
			EnableTextBox ();
		} else if (other.gameObject.name == "Athletic Teen Container") {
			currentLine = 10;
			endAtLine = 11;
			EnableTextBox ();
		}
	}

	private IEnumerator TextScroll (string lineOfText) {
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;
		while(isTyping && !cancelTyping && (letter < lineOfText.Length-1)) {
			theText.text += lineOfText [letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed);
		}
		theText.text = lineOfText;
		isTyping = false;
		cancelTyping = false;
	}

	public void EnableTextBox() {
		textBox.SetActive (true);
		isActive = true;
		if (stopPlayerMovement) {
			player.canMove = false;
		}
		StartCoroutine (TextScroll (textLines [currentLine]));
	}

	public void DisableTextBox() {
		textBox.SetActive (false);
		isActive = false;
		player.canMove = true;
	}

	public void ReloadScript(TextAsset theText) {
		if (theText != null) {
			textLines = new string[1];
			textLines = (textFile.text.Split ('\n'));
		}
	}

}
