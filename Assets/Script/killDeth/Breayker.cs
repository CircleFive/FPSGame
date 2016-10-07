using UnityEngine;
using System.Collections;

public class Breayker : MonoBehaviour {

    private GameObject bigCube;
    private GameObject cube;

    private GameObject cubeFind1;//プレイヤー
    private GameObject cubeFind2;//プレイヤー

    // 2点間の距離
    Vector3 pos;
    //移動速度
    float speed = 2f;

    void Start () {
        bigCube = (GameObject)Resources.Load("Prefabs/BigCube");
        cube = (GameObject)Resources.Load("Prefabs/Cube");

        cubeFind1 = GameObject.Find("Player1");
        cubeFind2 = GameObject.Find("Player2");
    }

void Update () {

        // Player1
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            cubeFind1.transform.position += new Vector3(-20 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            cubeFind1.transform.position += new Vector3(20 * Time.deltaTime, 0, 0);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cubeFind1.transform.position += new Vector3(0, 0, 20 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            cubeFind1.transform.position += new Vector3(0, 0, -20 * Time.deltaTime);
        }


        // Player2
        if (Input.GetKey(KeyCode.A))
        {
            cubeFind2.transform.position += new Vector3(-20 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cubeFind2.transform.position += new Vector3(20 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            cubeFind2.transform.position += new Vector3(0, 0, 20 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cubeFind2.transform.position += new Vector3(0, 0, -20 * Time.deltaTime);
        }

    }
}
