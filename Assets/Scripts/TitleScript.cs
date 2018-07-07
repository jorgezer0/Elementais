using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO.Ports;

public class TitleScript : MonoBehaviour {

	public GameObject P1Btn;
	public GameObject P2Btn;
	public Color On;
	public Color Off;

	static SerialPort stream = new SerialPort("COM3", 9600);

	// Use this for initialization
	void Start () {
//		stream.ReadTimeout = 50;
//		if (!stream.IsOpen) {
//			stream.Open ();
//		}
		
		//StartCoroutine ("BlinkButtons");
	}
	
	void Update(){
		if (Input.GetButtonDown ("Submit")){
			//StopCoroutine ("BlinkButtons");
			StartCoroutine ("OnePlayer");
		}
		if (Input.GetButtonDown ("Submit2P")){
			//StopCoroutine ("BlinkButtons");
			StartCoroutine ("TwoPlayers");
		}
	}

	IEnumerator BlinkButtons(){
		bool blinking = true;
		while (blinking == true) {
			P1Btn.GetComponent<SpriteRenderer> ().color = On;
			//WriteToArduino("11");
			P2Btn.GetComponent<SpriteRenderer> ().color = Off;
			//WriteToArduino("20");
			yield return new WaitForSeconds (1);
			P1Btn.GetComponent<SpriteRenderer> ().color = Off;
			//WriteToArduino("10");
			P2Btn.GetComponent<SpriteRenderer> ().color = On;
			//WriteToArduino("21");
			yield return new WaitForSeconds (1);
		}
	}

	IEnumerator OnePlayer(){
		P1Btn.GetComponent<SpriteRenderer> ().color = On;
		//WriteToArduino("11");
		P2Btn.GetComponent<SpriteRenderer> ().color = Off;
		//WriteToArduino("20");
		yield return new WaitForSeconds (.5f);
		PlayerPrefs.SetInt ("Players", 1);
		PlayerPrefs.SetInt ("Player", 1);
		SceneManager.LoadScene ("Main1P");
	}

	IEnumerator TwoPlayers(){
		P1Btn.GetComponent<SpriteRenderer> ().color = Off;
		//WriteToArduino("10");
		P2Btn.GetComponent<SpriteRenderer> ().color = On;
		//WriteToArduino("21");
		yield return new WaitForSeconds (.5f);
		PlayerPrefs.SetInt ("Players", 2);
		PlayerPrefs.SetInt ("Player", 1);
		SceneManager.LoadScene ("Main2P");
	}
		

//	public static void WriteToArduino(string message) {
//		stream.WriteLine(message);
//		stream.BaseStream.Flush();
//	}

}
