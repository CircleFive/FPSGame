using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

  //  objectHp player1Point;
  //  objectHp player2Point;

    // 引っ張てくるためのもの
    private GameObject textBox;
    // スコア表示用
    [SerializeField]
    private Text scoreText;



    void Start () {

        textBox = (GameObject)Resources.Load("Prefabs/BigClystal");
         //scoreText = textBox.GetComponent<Text>();
        //Debug.Log("score:" + scoreText.text);
        // 初期のスコア表示
        scoreText.text = "スコア：0-0";

    }

    void Update () {
        //objectHp playerPoint = textBox.GetComponent<objectHp>();
        ObjDestroy playerPoint = textBox.GetComponent<ObjDestroy>();
        // Debug.Log("player1:" + playerPoint.player1Point);
        // Debug.Log("player2:" + playerPoint.player2Point);
        Debug.Log("player1Point:" + playerPoint.Player1Point);
        scoreText.text = "スコア：" + playerPoint.Player1Point + "-" + playerPoint.Player2Point;
    }
}
