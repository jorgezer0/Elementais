using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScript : MonoBehaviour {

	public GameObject P1Btn;

	public Color On;
	public Color Off;

	bool isOn = true;
	bool statusChanged = true;

	// Use this for initialization
	void Start () {
		//stream = new SerialPort("COM3", 9600);
		
		StartCoroutine ("BlinkButtons");
	}

	/*
	void Update(){
		if (Input.GetButtonDown ("Submit")){
			StopCoroutine ("BlinkButtons");
			StartCoroutine ("OnePlayer");
		}
		if (Input.GetButtonDown ("Submit2P")){
			StopCoroutine ("BlinkButtons");
			StartCoroutine ("TwoPlayers");
		}
	}
	*/

	void Update()
	{
		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (P1Btn.GetComponent<BoxCollider2D>() == Physics2D.OverlapPoint(touchPos))
			{
				if ((isOn) && (statusChanged)) {
					Debug.Log ("TOUCH!");
					StopCoroutine ("BlinkButtons");
					StartCoroutine ("OnePlayer");
					statusChanged = false;
				}
			}
		}
		if (Input.touchCount == 0) {
			statusChanged = true;
		}
	}

	IEnumerator BlinkButtons(){
		bool blinking = true;
		while (blinking == true) {
			P1Btn.GetComponent<SpriteRenderer> ().color = On;
			yield return new WaitForSeconds (1);
			P1Btn.GetComponent<SpriteRenderer> ().color = Off;
			yield return new WaitForSeconds (1);
		}
	}

	IEnumerator OnePlayer(){
		P1Btn.GetComponent<SpriteRenderer> ().color = On;
		yield return new WaitForSeconds (.5f);
		PlayerPrefs.SetInt ("Players", 1);
		PlayerPrefs.SetInt ("Player", 1);
		SceneManager.LoadScene ("Main1P");
	}

}
