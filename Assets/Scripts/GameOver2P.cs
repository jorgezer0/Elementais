using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver2P : MonoBehaviour {

	//public TextMesh score;
	public TextMesh playerWin;

	// Use this for initialization
	void Start () {
		//Instantiate (gameOverPanel, new Vector3 (0, 0, -5), Quaternion.identity);
		//score.text = PlayerPrefs.GetInt ("Score").ToString();
		PlayerPrefs.SetInt ("Start", 0);
		PlayerPrefs.SetInt ("Timer", 0);
		PlayerPrefs.SetInt ("Pause", 0);
		PlayerPrefs.SetInt ("GameOver", 0);

		if (PlayerPrefs.GetInt("Player") == 1){
			playerWin.text = "Jogador 2";
		} else if (PlayerPrefs.GetInt("Player") == 2){
			playerWin.text = "Jogador 1";
		}

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
