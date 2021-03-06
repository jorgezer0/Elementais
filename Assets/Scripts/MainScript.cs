﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainScript : MonoBehaviour {

	public int[] colors;
	public int[] playerseq;
	public int colorcount;
	int seqCount = 0;
	int i;

	public TextMesh level;
	public TextMesh record;

	public AudioSource countdown;
	public AudioSource go;

	// Use this for initialization
	void Start () {
		colors = new int[100];
		playerseq = new int[100];
		colorcount = 0;
		PlayerPrefs.SetInt ("BtnVl", 0);
		PlayerPrefs.SetInt ("BtnClr", 0);

		record.text = ("Recorde: " + PlayerPrefs.GetInt ("Record").ToString ());
		//Test ();

		StartCoroutine ("StartCountdown");
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (PlayerPrefs.GetInt ("Start") == 1) {
			StartCoroutine ("StartCountdown");
			PlayerPrefs.SetInt ("Start", 2);
		}
		*/
		if (PlayerPrefs.GetInt ("Start") == 2) {
			level.text = colorcount.ToString ();
			PlayerPrefs.SetInt ("Score", colorcount);
		}

		if (PlayerPrefs.GetInt ("GameOver") == 1) {
			SceneManager.LoadScene ("GameOver");
			record.text = ("Recorde: " + PlayerPrefs.GetInt ("Record").ToString ());
		}
	}
		
	void NewColor_(){
		//PlayerPrefs.SetInt ("Timer", 2);
		i = Random.Range (1, 5);
		colors[colorcount] = i;
		colorcount++;
		PlayerPrefs.SetInt ("SeqCount", 0);
	}

	IEnumerator ShowSeq(){
		PlayerPrefs.SetInt ("Start", 1);
		level.text = colorcount.ToString ();
		//PlayerPrefs.SetInt ("Timer", 2);
		for (int k = 0; k < colorcount; k++){
			PlayerPrefs.SetInt ("BtnClr", colors [k]);
			yield return new WaitForSeconds (.7f);
			PlayerPrefs.SetInt ("Blinking", 0);
			PlayerPrefs.SetInt ("BtnClr", 0);
		}
		PlayerPrefs.SetInt ("Timer", 1);
		PlayerPrefs.SetInt ("Start", 2);
	}

	public void GetSequence(){
		Debug.Log ("SET!");
		int x = PlayerPrefs.GetInt ("BtnVl");
		playerseq [seqCount] = x;
		if (colors [seqCount] == playerseq [seqCount]) {
			Debug.Log ("Right!!");
			seqCount++;

			if (seqCount == colorcount) {
				PlayerPrefs.SetInt ("Timer", 2);
				StartCoroutine ("WaitTime");

				seqCount = 0;
			}
		} else {
			Debug.Log ("Wrong!!");
			if (colorcount > PlayerPrefs.GetInt ("Record")) {
				PlayerPrefs.SetInt ("Record", colorcount);
			}
			colorcount = 0;
			PlayerPrefs.SetInt ("Start", 0);
			PlayerPrefs.SetInt ("Timer", 0);

			Debug.Log (PlayerPrefs.GetInt ("Record"));
			PlayerPrefs.SetInt ("GameOver", 1);
		}
			
	}

	IEnumerator NextColors(){
		PlayerPrefs.SetInt ("Timer", 2);
		yield return new WaitForSeconds (.3f);
		NewColor_();
		StartCoroutine ("ShowSeq");
	}

	IEnumerator StartCountdown(){
		PlayerPrefs.SetInt ("Start", 0);
		Debug.Log ("CountDown Start!");
		for (int t = 3; t > 0; t--){
			level.text = t.ToString();
			countdown.Play();
			Debug.Log ("CountDown: " + t);
			yield return new WaitForSeconds(1);
		}
		go.Play ();
		StartCoroutine ("NextColors");
		PlayerPrefs.SetInt ("Start", 2);
	}

	IEnumerator WaitTime(){
		yield return new WaitForSeconds(1);
		StartCoroutine ("NextColors");
	}
	
}
