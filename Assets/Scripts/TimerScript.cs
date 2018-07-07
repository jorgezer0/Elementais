using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimerScript : MonoBehaviour {

	//Renderer rend;
	public float time = 5;
	//float rate;
	float i = 1f;

	public Image timeFill;

	public Color From;
	public Color To;

	//bool paused = false;
	bool timerRunning;


	// Use this for initialization
	void Start () {
		//StartCoroutine ("RadialTimer");
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Timer") == 1) {
			if (!timerRunning) {
				StartCoroutine ("RadialTimer");
			}
			i = 1;
			PlayerPrefs.SetInt ("Timer", 0);
		}

		if (PlayerPrefs.GetInt ("Timer") == 2) {
			i = 1;
			StopCoroutine ("RadialTimer");
			timerRunning = false;
		}

		timeFill.color = Color.Lerp (From, To, i);
	}

	IEnumerator RadialTimer()
	{
		timerRunning = true;
		float rate = 1 / time;
		i = 1;
		while (i > 0)
		{
			yield return null;
			timeFill.fillAmount = i;
			i -= Time.deltaTime * rate;
			//Debug.Log (i);

		}
		SceneManager.LoadScene ("GameOver");
	}

}
