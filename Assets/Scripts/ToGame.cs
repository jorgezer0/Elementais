using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ToGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update(){
		if (Input.GetButtonDown ("Submit")){
			SceneManager.LoadScene (2);
		}
	}
}
