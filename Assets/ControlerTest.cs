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
		for (int i = 0; i < 11; i++) {
			if (Input.GetKey ("joystick 1 button " + i.ToString ())) {
				print ("joystick 1 button " + i.ToString ());
			}
		}

		//h = Mathf.FloorToInt(Mathf.Abs(Input.GetAxisRaw ("Horizontal")));
		h = Input.GetAxisRaw ("Horizontal");
		print ("Horizontal:" + h);
		v = Input.GetAxisRaw ("Vertical");
		print ("Vertical:" + v);

	}
}
