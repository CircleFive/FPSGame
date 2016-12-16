using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChenge : MonoBehaviour {



    private bool stanbay1 = false;
    private bool stanbay2 = false;

    [SerializeField]
    private Image p1READY;
    [SerializeField]
    private Image p2READY;

    private float startDray = 0.0f;

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("button1_1") || Input.GetButtonDown("button2_1") || Input.GetButtonDown("button3_1") || Input.GetButtonDown("button4_1"))
        {
            stanbay1 = true;
            p1READY.GetComponent<Image>().enabled = true;
        }
        if (Input.GetButtonDown("button1_2") || Input.GetButtonDown("button2_2") || Input.GetButtonDown("button3_2") || Input.GetButtonDown("button4_2"))
        {
            stanbay2 = true;
            p2READY.GetComponent<Image>().enabled = true;
        }


        if (Input.GetKeyDown(KeyCode.Space) || stanbay1 && stanbay2)
        {
            startDray += Time.deltaTime;

            if(startDray >= 1.5f)
            SceneManager.LoadScene("Game");
        }
    }
}
