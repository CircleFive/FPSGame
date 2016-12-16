using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonFlash : MonoBehaviour {

    [SerializeField]
    private GameObject pushTo;

    private float flashTime = 0.0f;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        flashTime += Time.deltaTime;

        if (flashTime >= 0.5f)
        {
            pushTo.GetComponent<Image>().enabled = false;
        }
        if (flashTime >= 1f)
        {
            pushTo.GetComponent<Image>().enabled = true;
            flashTime = 0.0f;
        }

    }
}
