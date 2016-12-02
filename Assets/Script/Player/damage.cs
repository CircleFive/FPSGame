using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class damage : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    private bool hitCheck = false;

    public bool _HITCHECK
    {
        get { return hitCheck; }
        set { hitCheck = value; }
    }

    SpriteRenderer sr;
    Color d_Color;

    private Image image;


    private float arfa = 1;
    public float ARFA
    {
        get { return arfa;}
        set { arfa = value; }
    }


	// Use this for initialization
	void Start () {
        //sr = gameObject.GetComponent<SpriteRenderer>();
        //d_Color = sr.GetComponent<Color>();
        //arfa = d_Color.a;
        //d_Color = gameObject.GetComponent<SpriteRenderer>().color;
        d_Color = gameObject.GetComponent<Image>().color;
        arfa = d_Color.a;
        image = this.gameObject.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        maskStart();
	}



    void maskStart()
    {
        if (arfa <= 0) { return; }
        arfa = ARFA;
        arfa -= Time.deltaTime / 2;

        image.color = new Color(1, 1, 1, arfa);

        //d_Color = new Color(1, 1, 1, arfa);
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, arfa);
        //gameObject.GetComponent<SpriteRenderer>().color = d_Color;

    }

}
