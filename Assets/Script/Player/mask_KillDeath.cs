using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mask_KillDeath : MonoBehaviour
{

    private Image _thisImage;

    public float arfa;
    private Vector4 mask;

    // Use this for initialization
    void Start()
    {

        _thisImage = this.gameObject.GetComponent<Image>();
        mask = _thisImage.color;
        arfa = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        mask_GO();
    }

    void mask_GO()
    {
        if (arfa < 0) return;
        arfa -= Time.deltaTime;
        mask.w = arfa;
        _thisImage.color = mask;
    }


}
