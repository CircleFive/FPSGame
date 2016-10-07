using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VOD : MonoBehaviour {

    limitTime text;
    [SerializeField]
    private Text box;

    private GameObject manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.Find("GameObject");
        text = manager.GetComponent<limitTime>();

    }



    // Update is called once per frame
    void Update () {
        //Invoke("limit", 1f);
        box.text = text.pp;

    }



    void limit()
    {
        manager = GameObject.Find("GameObject");
        text = manager.GetComponent<limitTime>();

        box.text = text.pp;
        //box.text = "a";

    }
}
