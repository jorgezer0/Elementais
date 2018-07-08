using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	public string scene;
	public float sec;

    // Use this for initialization
    void Start() {
        StartCoroutine("Splash");
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator Splash()
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(scene);
    }

}
