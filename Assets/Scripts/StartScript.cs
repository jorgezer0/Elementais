using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	Renderer rend;
	bool faded = false;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Start", 0);
		PlayerPrefs.SetInt ("Timer", 0);
		PlayerPrefs.SetInt ("Pause", 0);
		PlayerPrefs.SetInt ("GameOver", 0);

		rend = GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Start") == 0 && faded) {
			StartCoroutine ("FadeIn");
		}
			
	}

	public void StartButton(){
		
		Debug.Log ("Start!!!" + PlayerPrefs.GetInt ("Start"));
		if (PlayerPrefs.GetInt ("Start") == 0) {
			PlayerPrefs.SetInt ("Start", 1);
			StartCoroutine ("FadeOut");
		}
		//StartCoroutine ("Blink");

	}

	IEnumerator FadeIn()
	{
		for (float f = 0f; f <= 1; f += 0.1f)
		{
			Color c = rend.material.color;
			c.a = f;
			rend.material.color = c;
			yield return new WaitForSeconds(.01f);
		}
		PlayerPrefs.SetInt ("Start", 0);
		faded = false;
		yield return null;
	}

	IEnumerator FadeOut()
	{
		for (float f = 1f; f >= 0; f -= 0.1f)
		{
			Color c = rend.material.color;
			c.a = f;
			rend.material.color = c;
			yield return new WaitForSeconds(.01f);
		}
		PlayerPrefs.SetInt ("Start", 1);
		faded = true;
		yield return null;
	}
}
