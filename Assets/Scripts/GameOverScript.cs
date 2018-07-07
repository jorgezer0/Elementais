using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public TextMesh score;
	public GameObject gameOverPanel;

	// Use this for initialization
	void Start () {
		//Instantiate (gameOverPanel, new Vector3 (0, 0, -5), Quaternion.identity);
		score.text = PlayerPrefs.GetInt ("Score").ToString();
		PlayerPrefs.SetInt ("Start", 0);
		PlayerPrefs.SetInt ("Timer", 0);
		PlayerPrefs.SetInt ("Pause", 0);
		PlayerPrefs.SetInt ("GameOver", 0);
		StartCoroutine ("RestartCountdown");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator RestartCountdown(){
		yield return new WaitForSeconds (30);
		SceneManager.LoadScene ("Title");
	}
}
