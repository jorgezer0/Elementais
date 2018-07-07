using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public int btnValue;
	public GameObject btn;
	public Sprite btnTexNorm;
	public Sprite btnTexBlink;

	public MainScript mainS;
	public MainScript_2P mainS2;
	AudioSource tone;

	public string ledOnValueP1;
	public string ledOffValueP1;
	public string ledOnValueP2;
	public string ledOffValueP2;

	// Use this for initialization
	void Start () {
		//Debug.Log ("CLICK!!!");
		btnTexNorm = GetComponent<SpriteRenderer>().sprite;
		PlayerPrefs.SetInt ("Blinking", 0);
		mainS = mainS.GetComponent<MainScript> ();
		tone = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Blinking") == 0 && PlayerPrefs.GetInt ("BtnClr") == btnValue) {
			StartCoroutine ("Blink");
			PlayerPrefs.SetInt ("Blinking", 1);
		}

	}

	/*
	void OnMouseOver(){
		if (Input.GetMouseButtonDown(0)){
			tone.Play();
			PlayerPrefs.SetInt ("Timer", 1);
			StartCoroutine ("BlinkOnTouch");
			Debug.Log ("CLICK!!!" + btnValue);
			PlayerPrefs.SetInt ("BtnVl", btnValue);
			mainS.GetSequence ();

		}
	}
	*/

	public void PressedButton(){
		tone.Play ();
		PlayerPrefs.SetInt ("Timer", 1);
		//StartCoroutine ("BlinkOnTouch");
		Debug.Log ("CLICK!!!" + btnValue);
		PlayerPrefs.SetInt ("BtnVl", btnValue);
		if (PlayerPrefs.GetInt ("Players") == 1) {
			mainS.GetSequence ();
		} else if (PlayerPrefs.GetInt ("Players") == 2) {
			mainS2.GetSequence ();
		}
	}


	private IEnumerator Blink(){
		PlayerPrefs.SetInt ("Blinking", 1);
		tone.Play();
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexBlink;
//		if (PlayerPrefs.GetInt ("Player") == 1) {
//			TitleScript.WriteToArduino (ledOnValueP1);
//		} else if (PlayerPrefs.GetInt ("Player") == 2) {
//			TitleScript.WriteToArduino (ledOnValueP2);
//		}
		yield return new WaitForSeconds (0.5f);
		StartCoroutine ("Normal");
	}

	IEnumerator Normal(){
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexNorm;
//		if (PlayerPrefs.GetInt ("Player") == 1) {
//			TitleScript.WriteToArduino (ledOffValueP1);
//		} else if (PlayerPrefs.GetInt ("Player") == 2) {
//			TitleScript.WriteToArduino (ledOffValueP2);
//		}
		yield return new WaitForSeconds (0.5f);
	}
	/*	
	IEnumerator BlinkOnTouch(){
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexBlink;
		yield return new WaitForSeconds(.5f);
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexNorm;

	}
	*/
	public void BlinkOn(){
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexBlink;
//		if (PlayerPrefs.GetInt ("Player") == 1) {
//			TitleScript.WriteToArduino (ledOnValueP1);
//		} else if (PlayerPrefs.GetInt ("Player") == 2) {
//			TitleScript.WriteToArduino (ledOnValueP2);
//		}
	}

	public void BlinkOff(){
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexNorm;
//		if (PlayerPrefs.GetInt ("Player") == 1) {
//			TitleScript.WriteToArduino (ledOffValueP1);
//		} else if (PlayerPrefs.GetInt ("Player") == 2) {
//			TitleScript.WriteToArduino (ledOffValueP2);
//		}
	}
}
