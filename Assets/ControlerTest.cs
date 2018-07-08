using UnityEngine;
using System.Collections;

public class ControlerTest : MonoBehaviour {

	float h;
	float v;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 1; i < 11; i++) {
			if (Input.GetKey ("joystick 1 button " + i.ToString ())) {
				print ("joystick 1 button " + i.ToString ());
			}
		}
		/*
		h = Input.GetAxis ("Horizontal");
		print (h);
		v = Input.GetAxis ("Vertical");
		print (v);
		*/
	}
}
