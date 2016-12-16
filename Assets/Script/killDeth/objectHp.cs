using UnityEngine;
using System.Collections;

public class objectHp : MonoBehaviour
{
    // オブジェクト
    private GameObject player1;
    private GameObject player2;
    private GameObject clystal;
    private GameObject bigClystal;

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


    //[SerializeField]
    //private GameObject bullet1;
    //[SerializeField]
    //private GameObject bullet2;


    public GameObject bullet1;
    public GameObject bullet2;


    // Player二人とCubeの位置確認の変数
    public Vector3 bullet1Pos1;    // BigCube
    public Vector3 bullet1Pos2;    // Cube

    public Vector3 bullet2Pos1;    // BigCube
    public Vector3 bullet2Pos2;    // Cube


    void Start()
    {
        // Resourcesフォルダにあるプレハブを代入
        clystal = (GameObject)Resources.Load("Prefabs/Clystal");
        bigClystal = (GameObject)Resources.Load("Prefabs/BigClystal");

        // Hierarchyにあるプレイヤーを代入
        //player1 = GameObject.Find("Player1");
        //player2 = GameObject.Find("Player2");

    }

    void Update()
    {
        /// PlayerとCubeの距離を代入
        // player1

        if (bullet1 == null || bullet2 == null) {
            return;
        }
        bullet1Pos1 = bullet1.transform.position - this.transform.position;
        bullet1Pos2 = bullet1.transform.position - this.transform.position;
        // player2
        bullet2Pos1 = bullet2.transform.position - this.transform.position;
        bullet2Pos2 = bullet2.transform.position - this.transform.position;


        // BigCubeが無い場合は無視
        if (GameObject.FindGameObjectsWithTag("BigClystal").Length > 0)
        {
            // Player1とCubeの距離を確認しHPを減らして0になれば消去。ポイントの加点
            //if (bullet1.tag == "bullet")
            //{
                //Debug.Log("当たり"+bullet1Pos1);
                if (bigClystal.tag == this.tag &&  bullet1Pos1.x < 1.55f && bullet1Pos1.x > -1.55f
                    && bullet1Pos1.z < 1.55f && bullet1Pos1.z > -1.55f)
                {


                bigCubeHp--;
                    //player1.transform.position = new Vector3(3.5f, 0.6f, 0);
                    if (bigCubeHp == 0)
                    {
                    Debug.Log("point");
                    //pointSet(player1Point, bigCubePoint);
                    player1Point += bigCubePoint;
                        Destroy(this.gameObject);
                    }
                }
            //}

            // Player2とCubeの距離を確認しHPを減らして0になれば消去。ポイントの加点             
            if (bullet2.tag == "bullet")
            {
                if (bigClystal.tag == this.tag && bullet2Pos1.x < 1.55f && bullet2Pos1.x > -1.55f
                && bullet2Pos1.z < 1.55f && bullet2Pos1.z > -1.55f)
                {
                    bigCubeHp--;
                    //player2.transform.position = new Vector3(3.5f, 0.6f, 0);
                    if (bigCubeHp == 0)
                    {
                        Debug.Log("point");
                        //  pointSet(player2Point, bigCubePoint);
                        player2Point += bigCubePoint;

                        Destroy(this.gameObject);
                    }
                }
            }
        }


        // Cubeが無い場合は無視
        if (GameObject.FindGameObjectsWithTag("Clystal").Length > 0)
        {
            if (bullet1.tag == "bullet")
            {
                if (clystal.tag == this.tag && bullet1Pos2.x < 1f && bullet1Pos2.x > -1f
                    && bullet1Pos2.z < 1f && bullet1Pos2.z > -1f)
                {
                    cubeHp--;
                    //player1.transform.position = new Vector3(3.5f, 0.6f, 0);
                    if (cubeHp == 0)
                    {
                        Debug.Log("point");
                        //   pointSet(player1Point, cubePoint);
                        player1Point += cubePoint;
                        Destroy(this.gameObject);
                    }
                }
            }

            if (bullet2.tag == "bullet")
            {
                if (clystal.tag == this.tag && bullet2Pos2.x < 1f && bullet2Pos2.x > -1f
                    && bullet2Pos2.z < 1f && bullet2Pos2.z > -1f)
                {
                    cubeHp--;
                    //player2.transform.position = new Vector3(3.5f, 0.6f, 0);
                    if (cubeHp == 0)
                    {
                        Debug.Log("point");

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
