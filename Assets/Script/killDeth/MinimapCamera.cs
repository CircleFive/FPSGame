using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;


public static class GameObjectUtils
{
    /// <summary>
    /// ルートに存在するゲームオブジェクトの配列を返します
    /// </summary>
    public static GameObject[] GetRootList()
    {
        return GameObject
            .FindObjectsOfType<GameObject>()
            .Where(c => c.transform.parent == null)
            .ToArray();
    }
}



public class MinimapCamera : MonoBehaviour
{

    private GameObject target;
    private GameObject mainCamera;
    private GameObject miniMapFind;
    private Camera miniMap;
    private GameObject panel;
    RectTransform rectTransform;
    private const float _height = 100f;
    private GameObject icon;
    
    // Icon
    private GameObject nearObj;      //最も近いオブジェクト
    private float searchTime = 0;      //経過時間
    float objDirection;

    // Margin
    float negativeMargin;
    float positiveMargin;

    void Start()
    {

        target = GameObject.Find("Player1");
        StartCoroutine(UpdatePosition());
        mainCamera = GameObject.Find("Main Camera");
        panel = GameObject.Find("Panel");
        rectTransform = panel.GetComponent<RectTransform>();
        icon = GameObject.Find("Icon");

        //最も近かったオブジェクトを取得
        //nearObj = serchTag(target, "Cube");
        //nearObj = serchTag(target, "BigCube");

    }

    void Update()
    {

        Vector3 cameraPos = mainCamera.transform.position;

        panel.transform.rotation = new Quaternion(0, 0, 0, 0);
        rectTransform.sizeDelta = new Vector2(200.5f, 65.5f);

        Clamp();


        //経過時間を取得
        searchTime += Time.deltaTime;

        //if (searchTime >= 1.0f)
        //{
        //    //最も近かったオブジェクトを取得
        //    nearObj = serchTag(target, "Cube");
        //    nearObj = serchTag(target, "BigCube");


        //    //経過時間を初期化
        //    searchTime = 0;
        //}

        List<GameObject> gameObjects = GetAllChildGameObjects(icon);

    }

    void Clamp()
    {
        //カメラ表示領域の左下をワールド座標に変換
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //カメラ表示領域の右上をワールド座標に変換
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // パネルの座標を取得
        Vector3 pos = panel.transform.position;
        
        // 固定する位置
         pos.x = Mathf.Clamp(pos.x, min.x+150f, min.x + 150f);
         pos.y = Mathf.Clamp(pos.y, min.y+90f, min.y + 90f);

        // 固定する位置の確定
        panel.transform.position = pos;

    
    }
    IEnumerator UpdatePosition()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            transform.position = new Vector3(target.transform.position.x, _height, target.transform.position.z);
            transform.eulerAngles = new Vector3(90f, 0f, -target.transform.eulerAngles.y);
        }
    }


    /// <param name="obj">子を取得したいGameObject</param>  
    /// <return>自分以外の全ての子のGameObjectのリスト</return>  

    public static List<GameObject> GetAllChildGameObjects(GameObject obj)
    {
        // objがnullなら、空のリストを返す  
        if (!obj)
            return new List<GameObject>();

        // 自分自身を含む全ての子のTransformを取得  
        Transform[] allTransform = obj.GetComponentsInChildren<Transform>();

        // 自分自身を除いたTransformをGameObjectに変換する  
        List<GameObject> gameObjects = new List<GameObject>();
        foreach (Transform t in allTransform)
        {
            // 自分自身でないなら  
            if (t != obj.transform)
            {
                // GameObjectに変換し、リストに追加する  
                gameObjects.Add(t.gameObject);
            }
        }

        // GameObjectのリストを返す  
        return gameObjects;
    }




/*
    //指定されたタグの中で最も近いものを取得
    GameObject *serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject[] targetObj = null; //オブジェクト
        int i = 0, j = 0;

        if (tagName == "Cube")
        {
            //タグ指定されたオブジェクトを配列で取得する
            foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
            {
                //自身と取得したオブジェクトの距離を取得
                tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

                //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
                //一時変数に距離を格納
                nearDis = tmpDis;
                //nearObjName = obs.name;
                if (targetObj[i] != null)
                {
                   targetObj[i] = null;
                }
                else
                {
                   targetObj[i] = obs;
                }
                i++;
            }
        }else
        {
            //タグ指定されたオブジェクトを配列で取得する
            GameObject obs = GameObject.Find(tagName);

            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            nearDis = tmpDis;
            //nearObjName = obs.name;
            if (targetObj[i] != null)
            {
                targetObj[i] = null;
            }
            else
            {
                targetObj[i] = obs;
            }
        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        for (j = 0; j < targetObj.Length; j++) {
            return targetObj[j];
        }
    }
*/
//指定されたタグの中で最も近いものを取得
GameObject serchDirection(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        if (tagName == "Cube")
        {
            //タグ指定されたオブジェクトを配列で取得する
            foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
            {

                //自身と取得したオブジェクトの距離を取得
                tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

                //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
                //一時変数に距離を格納
                if (nearDis == 0 || nearDis > tmpDis)
                {
                    nearDis = tmpDis;
                    //nearObjName = obs.name;
                    targetObj = obs;
                }

            }
        }
        else
        {
            //タグ指定されたオブジェクトを配列で取得する
            GameObject obs = GameObject.Find(tagName);

            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }
        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }



    /* // カメラの範囲から出ていないを確認して値を返す
    bool isOutOfScreen()
    {
        Vector3 positionInScreen = miniMap.WorldToViewportPoint(transform.position);
        positionInScreen.z = transform.position.z;

        if (positionInScreen.x <= negativeMargin ||
            positionInScreen.x >= positiveMargin ||
            positionInScreen.y <= negativeMargin ||
            positionInScreen.y >= positiveMargin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Updateに入れるもの
        if (this.isOutOfScreen())
        {
            Destroy(gameObject);
        }
    // Startに入れるもの
        miniMapFind = GameObject.Find("MiniMap");
        miniMap = miniMapFind.GetComponent<Camera>();


        negativeMargin = 0-1;
        positiveMargin = 1+1;


    */




    /*
        // Camera.current.nameから"SceneCamera"を排除すれば、GameViewのみで写っている場合に処理を行うといった事が出来る。
        void OnWillRenderObject()
        {

    #if UNITY_EDITOR
            if (Camera.current.name != "SceneCamera" && Camera.current.name != "Preview Camera")
    #endif
            {

                // 処理

            }

        }
    */
}