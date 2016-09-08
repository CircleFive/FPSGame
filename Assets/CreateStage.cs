using UnityEngine;
using System.Collections;

public class CreateStage : MonoBehaviour {

    // オブジェクトの高さ
    private int top1 = 100;
    private int top2 = 200;
    private int top3 = 300;



    // 配置するオブジェクト名
    string[] nomber1 = { "0","1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
    char[] nomber2 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };

    private int objScaleXY = 100;

    private GameObject wallTry;
    private GameObject wallCube;



    int i;
    int j;

    int stage1Scale = 12;
    int stage2Scale = 14;
    int stage3Scale = 16;

    //　ステージ
    /*  ルール
        
        高さ・・・オブジェクトの高さ（配列の高さではない）
        幅　・・・オブジェクトの幅（配列の幅ではない）

        高さ：幅( X × Z )
        0.　なし
        1.　2：1　// 四角、三角　・　幅（1×1） 落ちる
        2.　3：2　// 四角、三角　・　幅（2×2）
        3.　1：2　// 四角、三角　・　幅（2×2） 落ちる
        4.　2：3　// 三角　　　　・　幅（3×3）
        5.　1：2　// 三角　　　　・　幅（2×2）
        6.　2：1　// 三角　　　　・　幅（1×1）
        7.　必要なし　// サイズの関係で必要なくなったマス
        8.　5：10 // 壁
        9.　5：12 // 壁（端）
    */
    // 2次元配列
    int[,] stage1 = { 
        { 9, 8, 7, 7, 7, 7, 7, 7, 7, 7, 7, 9 },
        { 7, 2, 7, 0, 0, 0, 0, 0, 0, 3, 6, 7 },
        { 7, 7, 0, 0, 1, 0, 0, 0, 0, 0, 7, 7 },
        { 7, 0, 0, 2, 7, 0, 1, 2, 7, 0, 0, 7 },
        { 7, 0, 0, 7, 7, 0, 0, 7, 7, 1, 0, 7 },
        { 7, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 7 },
        { 7, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 7 },
        { 7, 0, 1, 2, 7, 0, 0, 2, 7, 0, 0, 7 },
        { 7, 0, 0, 7, 7, 1, 0, 7, 7, 0, 0, 7 },
        { 7, 3, 0, 0, 0, 0, 0, 1, 0, 0, 7, 7 },
        { 7, 6, 7, 0, 0, 0, 0, 0, 0, 7, 2, 7 },
        { 7, 8, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 },
    };

    /*
    int[,] stage2 = {
        { 9, 8, 7, 7, 7, 7, 7, 7, 7, 7, 7, 9 },
        { 7, 2, 7, 0, 0, 0, 0, 0, 0, 3, 1, 7 },
        { 7, 7, 0, 0, 1, 0, 0, 0, 0, 0, 7, 7 },
        { 7, 0, 0, 3, 7, 0, 1, 3, 7, 0, 0, 7 },
        { 7, 0, 0, 7, 7, 0, 0, 7, 7, 1, 0, 7 },
        { 7, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 7 },
        { 7, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 7 },
        { 7, 0, 1, 3, 7, 0, 0, 3, 7, 0, 0, 7 },
        { 7, 0, 0, 7, 7, 1, 0, 7, 7, 0, 0, 7 },
        { 7, 3, 0, 0, 0, 0, 0, 1, 0, 0, 7, 7 },
        { 7, 1, 7, 0, 0, 0, 0, 0, 0, 7, 2, 7 },
        { 7, 8, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 },
    };
    int[,] stage3 = {
        { 9, 8, 7, 7, 7, 7, 7, 7, 7, 7, 7, 9 },
        { 7, 2, 7, 0, 0, 0, 0, 0, 0, 3, 1, 7 },
        { 7, 7, 0, 0, 1, 0, 0, 0, 0, 0, 7, 7 },
        { 7, 0, 0, 3, 7, 0, 1, 3, 7, 0, 0, 7 },
        { 7, 0, 0, 7, 7, 0, 0, 7, 7, 1, 0, 7 },
        { 7, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 7 },
        { 7, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 7 },
        { 7, 0, 1, 3, 7, 0, 0, 3, 7, 0, 0, 7 },
        { 7, 0, 0, 7, 7, 1, 0, 7, 7, 0, 0, 7 },
        { 7, 3, 0, 0, 0, 0, 0, 1, 0, 0, 7, 7 },
        { 7, 1, 7, 0, 0, 0, 0, 0, 0, 7, 2, 7 },
        { 7, 8, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 },
    };

    */

    // 生成するオブジェクト
    /*  ルール

        1.　キューブ
        2.　三角形

    */
    int[,] stage1Obj = {
        { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,1 },
        { 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2 ,0 },
        { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
        { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
        { 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 2, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
        { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
        { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
    };

    /*　ルール
     *　
     *　stage ○ Objを見て1以上なら回転する角度を決めてください
     *　
     *　
     */

    // オブジェクトの角度
    float[,] stage1Rot = {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 90,0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
        { 0, 270, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
        { 0, 270, 0, 0, 0, 0, 0, 0, 0, 0, 180 ,0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 },
    };



    /*　ルール
     *　
     *　stage ○ Objを見て1以上ならscaleを決めてください
     *　1マス100scaleのため注意
     *　
     *　壁はXのみ
     *　
     */
    int wallScaleZ = 1;
    int[,] stage1ObjScl = {
        { 1000, 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000 },
        { 0, 200, 0, 0, 0, 0, 0, 0, 0, 200, 100, 0 },
        { 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 200, 0, 0, 50, 200, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0 },
        { 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0 },
        { 0, 0, 50, 200, 0, 0, 0, 200, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0 },
        { 0, 200, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0 },
        { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 200, 0 },
        { 0, 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };


    float objPosX = 0;
    float objPosZ = 0;


    float[,] stage1posX =
    {
        { 0.5f, 4.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, -0.5f },
        { 0, 0.5f, 0, 0, 0, 0, 0, 0, 0, 0.5f, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0.5f, 0, 0, 0, 0.5f, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0.5f, 0, 0, 0, 0.5f, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -0.5f, 0 },
        { 0, 4.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };


    float[,] stage1posY =
{
        { 1.5f, 1.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1.5f },
        { 0, 1.5f, 0, 0, 0, 0, 0, 0, 0, 0.5f, 2f, 0 },
        { 0, 0, 0, 0, 0.5f, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 1.5f, 0, 0, 0.5f, 1.5f, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.5f, 0, 0 },
        { 0, 0, 0, 0.5f, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0.5f, 0, 0, 0 },
        { 0, 0, 0.5f, 1.5f, 0, 0, 0, 1.5f, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0.5f, 0, 0, 0, 0, 0, 0 },
        { 0, 0.5f, 0, 0, 0, 0, 0, 0.5f, 0, 0, 0, 0 },
        { 0, 2f, 0, 0, 0, 0, 0, 0, 0, 0, 1.5f, 0 },
        { 0, 1.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };


    float[,] stage1posZ =
{
        { -5.5f, -0.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, -5.5f },
        { 0, -0.5f, 0, 0, 0, 0, 0, 0, 0, -0.5f, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, -0.5f, 0, 0, 0, -0.5f, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, -0.5f, 0, 0, 0, -0.5f, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, -0.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.5f, 0 },
        { 0, 0.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };


    void Start () {
        
        wallTry = (GameObject)Resources.Load("Prefabs/WallSankaku");
        wallCube = (GameObject)Resources.Load("Prefabs/WallCube");

        PhysicMaterial NPM = (PhysicMaterial)Resources.Load("Prehub/New Physic Material");

        //GameObject plane;
        //plane = (GameObject)Instantiate(wallCube);
        //plane.transform.localScale = new Vector3(1000, 1, 1000);

        for(i = 0; i < stage1Scale; i++)
        {
            for (j = 0; j < stage1Scale; j++)
            {
                GameObject obj;

                //GameObject obj = new GameObject();
                //obj.AddComponent<Renderer>();

                // stage1の番号1
                if (stage1[i, j] == 1)
                {
                    if (stage1Obj[i, j] == 1)
                    {
                        obj = (GameObject)Instantiate(wallCube, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y + stage1Rot[i, j], transform.rotation.z, 0));
                        obj.transform.localScale = new Vector3(stage1ObjScl[i,j],top1,stage1ObjScl[i,j]);
                        obj.transform.position = new Vector3(transform.position.x + objPosX, transform.position.y + stage1posY[i,j], transform.position.z + objPosZ);
                        obj.name = nomber1[i] + nomber2[j];
                        obj.tag = "CubeCollapce";
                        obj.transform.parent = this.transform;
                        obj.GetComponent<Renderer>().material.color = Color.white;
                        obj.AddComponent<BoxCollider>().material = NPM;

                        objPosX++;
                    }
                    else if(stage1Obj[i,j] == 2)
                    {

                        obj = (GameObject)Instantiate(wallTry, transform.position, new Quaternion(0, 0, 0, 0));
                        obj.transform.localScale = new Vector3(stage1ObjScl[i, j], top1, stage1ObjScl[i, j]);
                        obj.transform.Rotate(new Vector3(0, 1, 0), stage1Rot[i,j]);
                        obj.transform.position = new Vector3(transform.position.x + objPosX, transform.position.y + stage1posY[i, j], transform.position.z + objPosZ);
                        obj.name = nomber1[i] + nomber2[j];
                        obj.transform.parent = this.transform;
                        obj.GetComponent<Renderer>().material.color = Color.white;
                        obj.AddComponent<MeshCollider>().material = NPM;


                        objPosX++;
                    }
                }
                // stage1の番号2
                else if (stage1[i, j] == 2)
                {
                    if (stage1Obj[i, j] == 1)
                    {
                        obj = (GameObject)Instantiate(wallCube, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y + stage1Rot[i, j], transform.rotation.z, 0));
                        obj.transform.localScale = new Vector3(stage1ObjScl[i, j], top3, stage1ObjScl[i, j]);
                        obj.transform.position = new Vector3((transform.position.x + stage1posX[i, j]) + objPosX, transform.position.y + stage1posY[i, j], (transform.position.z + stage1posZ[i, j]) + objPosZ);
                        obj.name = nomber1[i] + nomber2[j];
                        obj.transform.parent = this.transform;
                        obj.AddComponent<BoxCollider>().material = NPM;

                        objPosX++;
                    }
                    else if (stage1Obj[i, j] == 2)
                    {

                        obj = (GameObject)Instantiate(wallTry, transform.position, new Quaternion(0, 0, 0, 0));
                        obj.transform.localScale = new Vector3(stage1ObjScl[i, j], top3, stage1ObjScl[i, j]);
                        obj.transform.Rotate(new Vector3(0, 1, 0), stage1Rot[i, j]);
                        obj.transform.position = new Vector3((transform.position.x + stage1posX[i, j]) + objPosX, transform.position.y + stage1posY[i, j], (transform.position.z + stage1posZ[i, j]) + objPosZ);
                        obj.name = nomber1[i] + nomber2[j];
                        obj.transform.parent = this.transform;
                        obj.AddComponent<MeshCollider>().material = NPM;


                        objPosX += 1f;
                    }
                }
                // stage1の番号3
                else if (stage1[i, j] == 3)
                {
                    if (stage1Obj[i, j] == 1)
                    {
                        obj = (GameObject)Instantiate(wallCube, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y + stage1Rot[i, j], transform.rotation.z, 0));
                        obj.transform.localScale = new Vector3(stage1ObjScl[i, j], top1, stage1ObjScl[i, j]);
                        obj.transform.position = new Vector3((transform.position.x + stage1posX[i, j]) + objPosX, transform.position.y + stage1posY[i, j], (transform.position.z + stage1posZ[i, j]) + objPosZ);
                        obj.name = nomber1[i] + nomber2[j];
                        obj.tag = "CubeCollapce";
                        obj.transform.parent = this.transform;
                        obj.GetComponent<Renderer>().material.color = Color.white;
                        obj.AddComponent<BoxCollider>().material = NPM;

                        objPosX++;
                    }
                    else if (stage1Obj[i, j] == 2)
                    {

                        obj = (GameObject)Instantiate(wallTry, transform.position, new Quaternion(0, 0, 0, 0));
                        obj.transform.localScale = new Vector3(stage1ObjScl[i, j], top1, stage1ObjScl[i, j]);
                        obj.transform.Rotate(new Vector3(0, 1, 0), stage1Rot[i, j]);
                        obj.transform.position = new Vector3((transform.position.x + stage1posX[i, j]) + objPosX, transform.position.y + stage1posY[i, j], (transform.position.z + stage1posZ[i, j]) + objPosZ);
                        obj.name = nomber1[i] + nomber2[j];
                        obj.tag = "CubeCollapce";
                        obj.GetComponent<Renderer>().material.color = Color.white;

                        obj.transform.parent = this.transform;
                        obj.AddComponent<MeshCollider>().material = NPM;

                        objPosX += 1f;
                    }
                }
                // stage1の番号6 (4,5 は無いので6を生成)
                else if (stage1[i, j] == 6)
                {
                    if (stage1Obj[i, j] == 1)
                    {
                        obj = (GameObject)Instantiate(wallCube, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y + stage1Rot[i, j], transform.rotation.z, 0));
                        obj.transform.localScale = new Vector3(stage1ObjScl[i, j], top2, stage1ObjScl[i, j]);
                        obj.transform.position = new Vector3((transform.position.x + stage1posX[i, j]) + objPosX, transform.position.y + stage1posY[i, j], (transform.position.z + stage1posZ[i, j]) + objPosZ);
                        obj.name = nomber1[i] + nomber2[j];
                        obj.transform.parent = this.transform;
                        obj.AddComponent<BoxCollider>().material = NPM;

                        objPosX++;
                    }
                    else if (stage1Obj[i, j] == 2)
                    {

                        obj = (GameObject)Instantiate(wallTry, transform.position, new Quaternion(0, 0, 0, 0));
                        obj.transform.localScale = new Vector3(stage1ObjScl[i, j], top2, stage1ObjScl[i, j]);
                        obj.transform.Rotate(new Vector3(0, 1, 0), stage1Rot[i, j]);
                        obj.transform.position = new Vector3((transform.position.x + stage1posX[i, j]) + objPosX, transform.position.y + stage1posY[i, j], (transform.position.z + stage1posZ[i, j]) + objPosZ);
                        obj.name = nomber1[i] + nomber2[j];
                        obj.transform.parent = this.transform;
                        obj.AddComponent<MeshCollider>().material = NPM;

                        objPosX += 1f;
                    }
                }
                // stage1の番号8 (7 は無いので8を生成.壁のため三角は無し)
                else if (stage1[i, j] == 8)
                {
                    if (stage1Obj[i, j] == 1)
                    {
                        obj = (GameObject)Instantiate(wallCube, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y + stage1Rot[i, j], transform.rotation.z, 0));
                        obj.transform.localScale = new Vector3(stage1ObjScl[i, j], top3, 1);
                        obj.transform.position = new Vector3((transform.position.x + stage1posX[i, j]) + objPosX, transform.position.y + stage1posY[i, j], (transform.position.z + stage1posZ[i, j]) + objPosZ);
                        obj.name = nomber1[i] + nomber2[j];
                        obj.transform.parent = this.transform;
                        obj.AddComponent<BoxCollider>().material = NPM;

                        objPosX++;
                    }
                }
                // stage1の番号9（壁のため三角は無し）
                else if (stage1[i, j] == 9)
                {
                    if (stage1Obj[i, j] == 1)
                    {
                        obj = (GameObject)Instantiate(wallCube, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y + stage1Rot[i, j], transform.rotation.z, 0));
                        obj.transform.localScale = new Vector3(1, top3, stage1ObjScl[i, j]);
                        obj.transform.position = new Vector3((transform.position.x + stage1posX[i, j]) + objPosX, transform.position.y + stage1posY[i, j], (transform.position.z + stage1posZ[i, j]) + objPosZ);
                        obj.name = nomber1[i] + nomber2[j];
                        obj.transform.parent = this.transform;
                        obj.AddComponent<BoxCollider>().material = NPM;

                        objPosX++;
                    }
                }

                else
                {
                    objPosX += 1f;
                }


            }
            objPosX = 0;
            objPosZ -= 1f;

        }




    }
	
	//void Update () {
	



	//}

    



}
