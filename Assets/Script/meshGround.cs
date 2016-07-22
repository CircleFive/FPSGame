using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class meshGround : MonoBehaviour
{

    // 頂点座標　※四角形なので4点
    [SerializeField]
    private Vector3[] vertices =
    {
        new Vector3(-1, 0, -1),   // 左下の頂点、頂点インデックス 0 番
        new Vector3(1, 0, -1),    // 右下の頂点、頂点インデックス 1 番
        new Vector3(1, 0, 1),     // 右上の頂点、頂点インデックス 2 番
        new Vector3(-1, 0, 1)     // 左上の頂点、頂点インデックス 3 番
    };

    // UV
    [SerializeField]
    private Vector2[] UV =
    {
        new Vector2(0, 0),      // 左下から
        new Vector2(1, 0),
        new Vector2(0, 1),
        new Vector2(1, 1)       // 右上へ
    };

    // 頂点インデックス
    [SerializeField]
    private int[] triangles =
    {
        0, 2, 1,    // 表は時計回り。左下 → 右上 → 右下
        0, 3, 2     // 表は時計回り。左下 → 左上 → 右上
    };

    void Start()
    {
        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = UV;
        mesh.triangles = triangles;

        // 法線とバウンディングボックスを再計算
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // 名前
        mesh.name = "meshGround";
        // 大きさ
        transform.localScale += new Vector3(5, 0, 5);

        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;

        // カラーコード指定　※Unity5.3以降対応
        Color color;
        ColorUtility.TryParseHtmlString("#228B22", out color);

        // Material取得のためにRendererコンポーネントを取得
        Renderer rend = GetComponent<MeshRenderer>();
        rend.GetComponent<MeshRenderer>().material.color = color;
    }
}