using UnityEngine;
using System.Collections;

public class SunshineScript : MonoBehaviour {

	public GameObject Sun1;
	public GameObject Sun2;

	public Color Alpha1;
	public Color Alpha2;

	// Use this for initialization
	void Start () {
		//StartCoroutine ("Sunshine");
	}
	
	// Update is called once per frame
	void Update () {
		Sun1.GetComponent<Transform> ().position += new Vector3 (Random.Range (-1f, 1f), Random.Range (-0.5f, 0.5f), 0) * Time.deltaTime;
		Sun2.GetComponent<Transform> ().position += new Vector3 (Random.Range (-1f, 1f), Random.Range (-0.5f, 0.5f), 0) * Time.deltaTime;
	}

	IEnumerator Sunshine(){
		while (1 != 2) {
			Alpha1.a = Random.Range (0.1f, 0.4f);
			Alpha2.a = Random.Range (0.1f, 0.4f);
			Sun1.GetComponent<SpriteRenderer> ().color = Color.Lerp (Alpha1, Alpha2, Mathf.PingPong (Time.time * 0.3f, 1));
			Sun2.GetComponent<SpriteRenderer> ().color = Color.Lerp (Alpha1, Alpha2, Mathf.PingPong (Time.time * 0.3f, 1));
			yield return new WaitForSeconds (3);
		}
	}
}
