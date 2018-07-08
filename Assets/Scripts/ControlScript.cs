using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlScript : MonoBehaviour {

	public List<GameObject> btn;
	public GameObject startBtn;

	// Use this for initialization
	void Start () {
	}
	/*
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Submit")){
			startBtn.GetComponent<StartScript> ().StartButton();
		}

		//P1 CONTROLLER:
		if (PlayerPrefs.GetInt ("Player") == 1) {
			if ((Input.GetButtonDown ("Fire1P1")) && (PlayerPrefs.GetInt ("Start") == 2)) {
				btn [0].GetComponent<ButtonScript> ().PressedButton ();
				btn [0].GetComponent<ButtonScript> ().BlinkOn ();
			}
			if ((Input.GetButtonDown ("Fire2P1")) && (PlayerPrefs.GetInt ("Start") == 2)) {
				btn [1].GetComponent<ButtonScript> ().PressedButton ();
				btn [1].GetComponent<ButtonScript> ().BlinkOn ();
			}
			if ((Input.GetButtonDown ("Fire3P1")) && (PlayerPrefs.GetInt ("Start") == 2)) {
				btn [2].GetComponent<ButtonScript> ().PressedButton ();
				btn [2].GetComponent<ButtonScript> ().BlinkOn ();
			}
			if ((Input.GetButtonDown ("Fire4P1")) && (PlayerPrefs.GetInt ("Start") == 2)) {
				btn [3].GetComponent<ButtonScript> ().PressedButton ();
				btn [3].GetComponent<ButtonScript> ().BlinkOn ();
			}
		}

		//P2 CONTROLLER:
		if (PlayerPrefs.GetInt ("Player") == 2) {
			if ((Input.GetButtonDown ("Fire1P2")) && (PlayerPrefs.GetInt ("Start") == 2)) {
				Debug.Log ("P2!!!");
				btn [0].GetComponent<ButtonScript> ().PressedButton ();
				btn [0].GetComponent<ButtonScript> ().BlinkOn ();
			}
			if ((Input.GetButtonDown ("Fire2P2")) && (PlayerPrefs.GetInt ("Start") == 2)) {
				Debug.Log ("P2!!!");
				btn [1].GetComponent<ButtonScript> ().PressedButton ();
				btn [1].GetComponent<ButtonScript> ().BlinkOn ();
			}
			if ((Input.GetButtonDown ("Fire3P2")) && (PlayerPrefs.GetInt ("Start") == 2)) {
				Debug.Log ("P2!!!");
				btn [2].GetComponent<ButtonScript> ().PressedButton ();
				btn [2].GetComponent<ButtonScript> ().BlinkOn ();
			}
			if ((Input.GetButtonDown ("Fire4P2")) && (PlayerPrefs.GetInt ("Start") == 2)) {
				Debug.Log ("P2!!!");
				btn [3].GetComponent<ButtonScript> ().PressedButton ();
				btn [3].GetComponent<ButtonScript> ().BlinkOn ();
			}
		}

		//BOOTH CONTROLERS
		if (((Input.GetButtonUp ("Fire1P1")) || (Input.GetButtonUp ("Fire1P2"))) && (PlayerPrefs.GetInt ("Start") == 2)) {
			btn [0].GetComponent<ButtonScript> ().BlinkOff ();
		}
		if (((Input.GetButtonUp ("Fire2P1")) || (Input.GetButtonUp ("Fire2P2"))) && (PlayerPrefs.GetInt ("Start") == 2)) {
			btn [1].GetComponent<ButtonScript> ().BlinkOff ();
		}
		if (((Input.GetButtonUp ("Fire3P1")) || (Input.GetButtonUp ("Fire3P2"))) && (PlayerPrefs.GetInt ("Start") == 2)) {
			btn [2].GetComponent<ButtonScript> ().BlinkOff ();
		}
		if (((Input.GetButtonUp ("Fire4P1")) || (Input.GetButtonUp ("Fire4P2"))) && (PlayerPrefs.GetInt ("Start") == 2)) {
			btn [3].GetComponent<ButtonScript> ().BlinkOff ();
		}


	}*/
}
