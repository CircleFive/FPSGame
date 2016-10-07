using UnityEngine;
using System.Collections;

public class objectHp : MonoBehaviour
{
    // オブジェクト
    private GameObject player1;
    private GameObject player2;
    private GameObject cube;
    private GameObject bigCube;

    // Cubeの耐久力
    int bigCubeHp = 3;
    int cubeHp = 1;
    // Cube破壊によるのポイント
    int bigCubePoint = 3;
    int cubePoint = 1;

    // ポイント加点
    [SerializeField]
    static private int player1Point; // Player1が獲得したポイント
    [SerializeField]
    static private int player2Point; // Player2が獲得したポイント

    public int Player1Point
    {
        get { return player1Point; }
        set { player1Point = value; }
    }
    public int Player2Point
    {
        get { return player2Point; }
        set { player2Point = value; }
    }


    // Player二人とCubeの位置確認の変数
    Vector3 player1Pos1;    // BigCube
    Vector3 player1Pos2;    // Cube

    Vector3 player2Pos1;    // BigCube
    Vector3 player2Pos2;    // Cube


    void Start()
    {
        // Resourcesフォルダにあるプレハブを代入
        cube = (GameObject)Resources.Load("Prefabs/Clystal");
        bigCube = (GameObject)Resources.Load("Prefabs/BigClystal");

        // Hierarchyにあるプレイヤーを代入
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

    }

    void Update()
    {
        /// PlayerとCubeの距離を代入
        // player1
        player1Pos1 = player1.transform.position - this.transform.position;
        player1Pos2 = player1.transform.position - this.transform.position;
        // player2
        player2Pos1 = player2.transform.position - this.transform.position;
        player2Pos2 = player2.transform.position - this.transform.position;


        // BigCubeが無い場合は無視
        if (GameObject.FindGameObjectsWithTag("BigCube").Length > 0)
        {
            // Player1とCubeの距離を確認しHPを減らして0になれば消去。ポイントの加点
            if (player1.tag == "Player1")
            {
                if (bigCube.tag == this.tag && player1Pos1.x < 1.55f && player1Pos1.x > -1.55f
                    && player1Pos1.z < 1.55f && player1Pos1.z > -1.55f)
                {
                    bigCubeHp--;
                    player1.transform.position = new Vector3(3.5f, 0.6f, 0);
                    if (bigCubeHp == 0)
                    {
                        //pointSet(player1Point, bigCubePoint);
                        player1Point += bigCubePoint;
                        Destroy(this.gameObject);
                    }
                }
            }

            // Player2とCubeの距離を確認しHPを減らして0になれば消去。ポイントの加点             
            if (player2.tag == "Player2")
            {
                if (bigCube.tag == this.tag && player2Pos1.x < 1.55f && player2Pos1.x > -1.55f
                && player2Pos1.z < 1.55f && player2Pos1.z > -1.55f)
                {
                    bigCubeHp--;
                    player2.transform.position = new Vector3(3.5f, 0.6f, 0);
                    if (bigCubeHp == 0)
                    {
                        //  pointSet(player2Point, bigCubePoint);
                        player2Point += bigCubePoint;

                        Destroy(this.gameObject);
                    }
                }
            }
        }


        // Cubeが無い場合は無視
        if (GameObject.FindGameObjectsWithTag("Cube").Length > 0)
        {
            if (player1.tag == "Player1")
            {
                if (cube.tag == this.tag && player1Pos2.x < 1f && player1Pos2.x > -1f
                    && player1Pos2.z < 1f && player1Pos2.z > -1f)
                {
                    cubeHp--;
                    player1.transform.position = new Vector3(3.5f, 0.6f, 0);
                    if (cubeHp == 0)
                    {
                        //   pointSet(player1Point, cubePoint);
                        player1Point += cubePoint;
                        Destroy(this.gameObject);
                    }
                }
            }

            if (player2.tag == "Player2")
            {
                if (cube.tag == this.tag && player2Pos2.x < 1f && player2Pos2.x > -1f
                    && player2Pos2.z < 1f && player2Pos2.z > -1f)
                {
                    cubeHp--;
                    player2.transform.position = new Vector3(3.5f, 0.6f, 0);
                    if (cubeHp == 0)
                    {
                        //pointSet(player2Point, cubePoint);
                        player2Point += cubePoint;
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
                bigCubeHp--;
              
                if (bigCubeHp == 0)
                {
                    //pointSet(player1Point, bigCubePoint);
                    player1Point += bigCubePoint;
                    Destroy(this.gameObject);
                }
            
        }

        // Player2とCubeの距離を確認しHPを減らして0になれば消去。ポイントの加点             
        if (other.tag == "Bullet2")
        {
            bigCubeHp--;

            if (bigCubeHp == 0)
            {
                //pointSet(player1Point, bigCubePoint);
                player2Point += bigCubePoint;
                Destroy(this.gameObject);
            }

        }
    }



    public string result()
    {
        if (Player1Point > Player2Point)
        {
            return "Player1";
        }
        else if (Player1Point < Player2Point)
        {
            return "Player2";
        }
        else
        {
            return "Draw";
        }

    }


}
