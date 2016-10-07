using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {

    /// <summary>
    /// 表示用のバウンディングボックス(Prefab)
    /// </summary>
    [SerializeField]
    private GameObject bounds;

    /// <summary>
    /// 表示用のバウンディングボックス
    /// </summary>
    private GameObject newBounds;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        newBounds = Instantiate(bounds, transform.position, Quaternion.identity) as GameObject;
    }

    /// <summary>
    /// バウンディングボックスの表示更新
    /// </summary>
    private void Update()
    {
        var col = GetComponent<Collider>();
        if (col == null)
        {
            newBounds.SetActive(false);
        }
        else {
            newBounds.SetActive(true);
            newBounds.transform.localScale = col.bounds.size;
        }
    }
}
