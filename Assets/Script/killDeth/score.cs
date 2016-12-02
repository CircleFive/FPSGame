using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

    // 旧バージョン
    // 引っ張てくるためのもの
    //private GameObject p;
    // スコア表示用
    //[SerializeField]
    //private Text scoreText;

    [SerializeField]
    private GameObject player;
    private string p_name;

    [SerializeField]
    private Text pKill;
    [SerializeField]
    private Text pDeath;

    ObjDestroy pKD;
    private GameObject C;



    private string p_Kill;
    private string p_Death;
    //private string p2KD;

    void Start () {

        /* 旧バージョン
        //p = GameObject.Find("Player1");
        //scoreText = textBox.GetComponent<Text>();
        //Debug.Log("score:" + scoreText.text);
        // 初期のスコア表示
        scoreText.text = "スコア：0-0";
        */
        p_name = player.name;
        C = (GameObject)Resources.Load("Prefabs/BigClystal");
        pKD = C.GetComponent<ObjDestroy>();

    }

    void Update () {
        //ObjDestroy playerPoint = p.GetComponent<ObjDestroy>();
        //scoreText.text = "スコア：" + playerPoint.Player1Point + "-" + playerPoint.Player2Point;
        getPoint(p_name);
        setPoint();
    }

    void getPoint(string name)
    {
        if(name == "Player1")
        {
            p_Kill = pKD.p1_kill().ToString();
            p_Death = pKD.p2_kill().ToString();
        }
        else if (name == "Player2")
        {
            p_Kill = pKD.p2_kill().ToString();
            p_Death = pKD.p1_kill().ToString();
        }
    }
    void setPoint()
    {
         pKill.text = p_Kill;
         pDeath.text = p_Death;
    }


}
