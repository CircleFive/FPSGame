using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class limitTime : MonoBehaviour {

    float playTime = 180;
    [SerializeField]
    private Text timeText;
    private GameObject C;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private GameObject panel;

    public string V_O_D; // Victory or defeat

    objectHp p;
    public string pp;

    void limit()
    {
        p = C.GetComponent<objectHp>();
    }

    // Use this for initialization
    void Start () {
        //Application.LoadLevelAdditive(V_O_D);
        C = (GameObject)Resources.Load("Prefabs/BigCube");
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(canvas);
    }

    // Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (playTime > 0)
                playTime -= Time.deltaTime;

            timeText.text = playTime.ToString("#.0");
            Invoke("limit", 1f);
            if (playTime < 0)
            {
                timeText.text = "0.0";
                playTime = 0;

                Debug.Log(p.result());
                pp = p.result();

                panel.transform.parent = null;
                camera.transform.parent = null;
                //SceneManager.LoadScene(V_O_D);
                SceneManager.LoadScene("result");

            }
        }
        else if(SceneManager.GetActiveScene().name == "result")
        {

        }
    }
}
