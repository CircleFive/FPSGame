using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TitleText : MonoBehaviour {

    [SerializeField]
    private GameObject pushTo;

    float textTime = 0.0f;

	void Start () {
        pushTo.GetComponent<Text>().text = "PUSH TO SPACEKEY";
	}
	
	void Update () {
        textTime += Time.deltaTime;

        if (textTime >= 0.5f)
        {
            pushTo.GetComponent<Text>().enabled = false;
        }
        if(textTime >= 1f)
        {
            pushTo.GetComponent<Text>().enabled = true;
            textTime = 0.0f;
        }

    }
}
