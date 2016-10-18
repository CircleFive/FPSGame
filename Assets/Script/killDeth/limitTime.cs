using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class limitTime : MonoBehaviour {

    float playTime = 2;
    [SerializeField]
    private Text timeText;
    private GameObject C;
    //[SerializeField]
    //private GameObject canvas;
    //[SerializeField]
    //private GameObject camera;
    //[SerializeField]
    //private GameObject panel;

    public string V_O_D; // Victory or defeat

    ObjDestroy p;
    public string pp;
    public string p1Kill;
    public string p2Kill;
    public string p1Point;
    public string p2Point;
    public string p1Total;
    public string p2Total;

    int t1;
    int t2;

    int p1;
    int p2;

    int k1;
    int k2;

    void limit()
    {
        p = C.GetComponent<ObjDestroy>();
    }

    // Use this for initialization
    void Start () {
        //Application.LoadLevelAdditive(V_O_D);
        C = (GameObject)Resources.Load("Prefabs/BigClystal");
        DontDestroyOnLoad(this);
        //DontDestroyOnLoad(canvas);
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

                p1 = p.po1();
                p2 = p.po2();

                k1 = p.p1_kill();
                k2 = p.p2_kill();

                t1 = p1 + k1 - k2;
                t2 = p2 + k2 - k1;
                
                

                pp = p.result();
                p1Kill = k1.ToString();
                p2Kill = k2.ToString();
                p1Point = p1.ToString();
                p2Point = p2.ToString();
                p1Total = t1.ToString();
                p2Total = t2.ToString();

                //SceneManager.LoadScene("result");

            }
        }
        else if(SceneManager.GetActiveScene().name == "result")
        {

        }
    }
}
