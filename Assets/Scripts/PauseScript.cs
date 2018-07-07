using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GameObject pauseBtn;
	public Sprite pauseTexNorm;
	public Sprite pauseTexDown;

	public GameObject pausePanel;


	// Use this for initialization
	void Start () {
		pauseTexNorm = GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown(0)){
			if (PlayerPrefs.GetInt ("Pause") == 0) {
				Debug.Log ("Pause!");
				PlayerPrefs.SetInt ("Pause", 1);
				pauseBtn.GetComponent<SpriteRenderer> ().sprite = pauseTexDown;
				Instantiate (pausePanel, new Vector3(0,0,-3), Quaternion.identity);
				Debug.Log (PlayerPrefs.GetInt ("Pause"));
			} else if (PlayerPrefs.GetInt ("Pause") == 1) {
				Debug.Log ("UnPause!");
				PlayerPrefs.SetInt ("Pause", 0);
				pauseBtn.GetComponent<SpriteRenderer> ().sprite = pauseTexNorm;
				GameObject pausePanelds = GameObject.Find ("PausePanel(Clone)");
				Destroy (pausePanelds);
				Debug.Log (PlayerPrefs.GetInt ("Pause"));
			}
		}
	}

}
