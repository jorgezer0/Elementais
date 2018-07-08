using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public int btnValue;
	public GameObject btn;
	public Sprite btnTexNorm;
	public Sprite btnTexBlink;

	public MainScript mainS;
	AudioSource tone;

	bool statusChanged = false;

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
		if ((PlayerPrefs.GetInt ("Blinking") == 0) && (PlayerPrefs.GetInt ("BtnClr") == btnValue)) {
			StopAllCoroutines ();
			StartCoroutine ("Blink");
			PlayerPrefs.SetInt ("Blinking", 1);
		}

		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (GetComponent<BoxCollider2D>() == Physics2D.OverlapPoint(touchPos))
			{
				if (!statusChanged) {
					Debug.Log ("TOUCH!");
					tone.Play ();
					BlinkOn ();
					PlayerPrefs.SetInt ("Timer", 1);
					Debug.Log ("CLICK!!!" + btnValue);
					PlayerPrefs.SetInt ("BtnVl", btnValue);
					mainS.GetSequence ();
					statusChanged = true;
				}
			}

		}
		if (Input.touchCount == 0) {
			BlinkOff ();
			statusChanged = false;
		}
	}
		
//	IEnumerator Blink(){
//		//PlayerPrefs.SetInt ("Blinking", 1);
//		tone.Play();
//		Debug.Log ("Blink!");
//		btn.GetComponent<SpriteRenderer> ().sprite = btnTexBlink;
//		Debug.Log (btnValue);
//		yield return new WaitForSeconds (0.5f);
//		//StartCoroutine ("Normal");
//		Debug.Log ("Blink End.");
//	}
//
//	IEnumerator Normal(){
//		btn.GetComponent<SpriteRenderer> ().sprite = btnTexNorm;
//		yield return new WaitForSeconds (0.5f);
//	}
//
//	public void BlinkOn(){
//		btn.GetComponent<SpriteRenderer> ().sprite = btnTexBlink;
//	}
//
//	public void BlinkOff(){
//		btn.GetComponent<SpriteRenderer> ().sprite = btnTexNorm;
//	}
	public IEnumerator Blink(){
		//PlayerPrefs.SetInt ("Blinking", 1);
		tone.Play();
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexBlink;
		yield return new WaitForSeconds (0.5f);
		StartCoroutine("Normal");
	}

	IEnumerator Normal(){
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexNorm;

		yield return new WaitForSeconds (0.2f);
		//PlayerPrefs.SetInt("Blinking", 0);
	}
	/*	
	IEnumerator BlinkOnTouch(){
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexBlink;
		yield return new WaitForSeconds(.5f);
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexNorm;

	}
	*/
	public void BlinkOn(){
		//btn.GetComponent<SpriteRenderer> ().sprite = btnTexBlink;
		//yield return new WaitForSeconds(1);
		StartCoroutine("Blink");

	}

	public IEnumerator BlinkOff(){
		btn.GetComponent<SpriteRenderer> ().sprite = btnTexNorm;
		yield return null;
	}

}
