using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class imageScale : MonoBehaviour {

    [SerializeField]
    private RectTransform panelScale;
    [SerializeField]
    private Vector3 panelPosition;

    Vector2 panel;

    void Start () {
        //panel = GetComponent<RectTransform>();
        panel = new Vector2(this.GetComponent<RectTransform>().rect.width, this.GetComponent<RectTransform>().rect.height);
 //       panelScale = GetComponent<RectTransform>();
    }

    void Update () {
        //カメラ表示領域の左下をワールド座標に変換
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //カメラ表示領域の右上をワールド座標に変換
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //panel.sizeDelta = new Vector3(100, 100);
        //panel.rect = new Vector4(0.08030073f, 2.023478f, 1,0);
        //    panelPosition = new Vector3(this.transform.position.x, this.transform.position.y + max.y, transform.position.z);
        //    panelScale = new Vector3(0.08030073f, 2.023478f, 1);

        //this.transform.localScale = panelScale;

        //panel = new Vector2(0.08030073f, 2.023478f);
        panel = new Vector2(0.1065725f, 1.628722f);


        this.transform.localScale = new Vector3(panel.x, panel.y, 1);


        //  this.transform.localScale = panelPosition;

    }
}
