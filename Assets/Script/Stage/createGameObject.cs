using UnityEngine;
using System.Collections;

public class createGameObject : MonoBehaviour {

    private GameObject cubes;
    //private GameObject cube;
    //private GameObject bigCube;
    private GameObject clystal;
    private GameObject bigClystal;

    Vector3 pos;

    // y軸は同一
    float yy = 0.5f;

    // 出現位置
    float xx;
    float zz;

    // 同じ位置に出現させないための配列
    //int[] memory = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    int[] memory = { 0, 0, 0, 0, 0, 0, 0 };
    // 出現カウント
    int cubeCnt = 0;
    /// <summary>
    /// 
    /// 15か所の座標[x,y,z]y軸は固定
    /// for文で回してxPoint[0]とzPoint[0]が対になってます.(他も同様) 
    /// 
    /// </summary>
    //float[] xPoint = {5,10,-5,-10,15,-15,20,-20,25,-25,30,-30,35,-35,40 };
    //float[] zPoint = {5,10,-5,-10,15,-15,20,-20,25,-25,30,-30,35,-35,40 };
    float[] xPoint = { -2.6f,  4.2f, 3.6f,    0, -3.6f,    -4, 2.6f};
    float[] yPoint = {  0.5f,  1.5f, 1.5f, 0.5f,  1.5f,  1.5f, 0.5f };
    float[] zPoint = {  3.6f, 4.05f, 1.5f,    0, -1.5f, -4.1f, -3.6f};

    // for文に使用
    int i;
    int j;

    // 全てのCubeが消えたときbigCubeが出現し再び小さいCubeが＋2して出すための変数
    int cubeRevenge = 0;

    // 小さいcubeが出現したかどうか
    bool cubeOn = true;

    // 出現するClystalの数
    int cCount = 7;

    void Start () {
        cubes = GameObject.Find("CreateStage");
        //cube = (GameObject)Resources.Load("Prefabs/Cube");
        //bigCube = (GameObject)Resources.Load("Prefabs/BigCube");
        clystal = (GameObject)Resources.Load("Prefabs/Clystal");
        bigClystal = (GameObject)Resources.Load("Prefabs/BigClystal");
    }

    void Update() {

        if (GameObject.FindGameObjectsWithTag("BigClystal").Length == 0 && cubeCnt != 4)
        {
            if (cubeOn == false && cubeRevenge <= 7)
            {
                for (j = 0; j < 3 + cubeRevenge; j++)
                {
                    int ran = Random.Range(0, cCount);

                    if (memory[ran] == 1) { 

                        while(memory[ran] == 1)
                        {
                            ran = Random.Range(0, cCount);
                        }
                    }
                    memory[ran] = 1;

                    switch (ran)
                    {
                        case 0:
                            xx = xPoint[ran];
                            zz = zPoint[ran];
                            break;
                        case 1:
                            xx = xPoint[ran];
                            zz = zPoint[ran];
                            break;
                        case 2:
                            xx = xPoint[ran];
                            zz = zPoint[ran];
                            break;
                        case 3:
                            xx = xPoint[ran];
                            zz = zPoint[ran];
                            break;
                        case 4:
                            xx = xPoint[ran];
                            zz = zPoint[ran];
                            break;
                        case 5:
                            xx = xPoint[ran];
                            zz = zPoint[ran];
                            break;
                        case 6:
                            xx = xPoint[ran];
                            zz = zPoint[ran];
                            break;
                        //case 7:
                        //    xx = xPoint[ran];
                        //    zz = zPoint[ran];
                        //    break;
                        //case 8:
                        //    xx = xPoint[ran];
                        //    zz = zPoint[ran];
                        //    break;
                        //case 9:
                        //    xx = xPoint[ran];
                        //    zz = zPoint[ran];
                        //    break;
                        //case 10:
                        //    xx = xPoint[ran];
                        //    zz = zPoint[ran];
                        //    break;
                        //case 11:
                        //    xx = xPoint[ran];
                        //    zz = zPoint[ran];
                        //    break;
                        //case 12:
                        //    xx = xPoint[ran];
                        //    zz = zPoint[ran];
                        //    break;
                        //case 13:
                        //    xx = xPoint[ran];
                        //    zz = zPoint[ran];
                        //    break;
                        //case 14:
                        //    xx = xPoint[ran];
                        //    zz = zPoint[ran];
                        //    break;

                    }
                    Vector3 asd = gameObject.transform.position;
                    pos = new Vector3(xx, yy, zz);
                    GameObject obj = (GameObject)Instantiate(clystal, pos, transform.rotation);
                    obj.transform.parent = cubes.transform;
                    obj.AddComponent<BoxCollider>();
                    if (j == 2 + cubeRevenge)
                    {
                        cubeOn = true;
                        cubeRevenge += 4;
                        for (int l = 0; l < cCount; l++)
                        {
                            memory[l] = 0;
                        }
                        cubeCnt++;
                        break;

                    }
                }
                }
        }
        if (GameObject.FindGameObjectsWithTag("Clystal").Length == 0 && cubeOn == true)
        {
            cubeOn = false;
            GameObject obj = (GameObject)Instantiate(bigClystal, new Vector3(0, 1, 0), transform.rotation);
            obj.transform.parent = cubes.transform;
            obj.AddComponent<BoxCollider>();

        }
    }
}
