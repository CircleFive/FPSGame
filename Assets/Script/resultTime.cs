using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class resultTime : MonoBehaviour {

    private float time = 25.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if(time <= 0 || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Title");
        }

    }
}
