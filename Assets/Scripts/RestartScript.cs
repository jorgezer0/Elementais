using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartScript : MonoBehaviour {

	bool isOn = true;
	bool statusChanged = true;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update(){
		if (Input.GetButtonDown ("Submit")){
			SceneManager.LoadScene (0);
		}

		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (GetComponent<BoxCollider2D>() == Physics2D.OverlapPoint(touchPos))
			{
				if ((isOn) && (statusChanged)) {
					Debug.Log ("TOUCH!");
					SceneManager.LoadScene (0);
					statusChanged = false;
				}
			}

		}
		if (Input.touchCount == 0) {
			statusChanged = true;
		}
	}
}
