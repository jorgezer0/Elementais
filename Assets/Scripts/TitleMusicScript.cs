using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleMusicScript : MonoBehaviour {

	static bool AudioBegin = false; 

	void Awake()
	{
		if (!AudioBegin) {
			GetComponent<AudioSource>().Play ();
			DontDestroyOnLoad (this.gameObject);
			AudioBegin = true;
		} 
	}
	void Update () {
		if((SceneManager.GetActiveScene().name == "Main1P") || (SceneManager.GetActiveScene().name == "Main2P")){
			//GetComponent<AudioSource>().Stop ();
			StartCoroutine("FadeOut");
			AudioBegin = false;
		}
	}

	IEnumerator FadeOut(){
		for (float t = 1; t > 0; t -= 0.5f) {
			GetComponent<AudioSource> ().volume = t;
		}
		yield return null;
		Destroy (this.gameObject);
	}
}
