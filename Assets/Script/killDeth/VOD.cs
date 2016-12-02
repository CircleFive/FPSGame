using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VOD : MonoBehaviour {

    limitTime text;

    [SerializeField]
    private Text Kill1;
    [SerializeField]
    private Text Kill2;
    [SerializeField]
    private Text Death1;
    [SerializeField]
    private Text Death2;
    //[SerializeField]
    //private Text Total1;
    //[SerializeField]
    //private Text Total2;
    //[SerializeField]
    //private Text Text;
    //[SerializeField]
    //private Text Text;
    [SerializeField]
    private Image VODUI;




    [SerializeField]
    private Text Text_R;




    [SerializeField]
    private GameObject hanabi1;
    [SerializeField]
    private GameObject hanabi2;
    [SerializeField]
    private GameObject hanabi3;
    [SerializeField]
    private GameObject hanabi4;
    [SerializeField]
    private GameObject hanabi5;
    [SerializeField]
    private GameObject hanabi6;
    [SerializeField]
    private GameObject hanabi7;







    private GameObject manager;

    void Start () {
        manager = GameObject.Find("GameObject");
        text = manager.GetComponent<limitTime>();

        if (text.pp == "DRAW")
        {
            hanabi1.SetActive(false);
            hanabi2.SetActive(false);
            hanabi3.SetActive(false);
            hanabi4.SetActive(false);
            hanabi5.SetActive(false);
            hanabi6.SetActive(false);
            hanabi7.SetActive(false);
        }

    }



    // Update is called once per frame
    void Update () {
        //Invoke("limit", 1f);

        Kill1.text = text.p1Kill;
        Kill2.text = text.p2Kill;
        Death1.text = text.p2Kill;
        Death2.text = text.p1Kill;
        //Total1.text = text.p1Total;
        //Total2.text = text.p2Total;


        //if (text.pp == "DRAW")
        //{
        //    Text_R.color = new Color(0f, 1f, 1f);
        //}else if(text.textColor == "red")
        //{
        //    Text_R.color = new Color(1f, 0f, 0f);
        //}else if(text.textColor == "blue")
        //{
        //    Text_R.color = new Color(0f, 0f, 1f);
        //}
        //Text_R.text= text.pp;
        if (text.pp == "DRAW")
        {
            VODUI.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/result/DRAW");
        }
        else if (text.textColor == "p1")
        {
            VODUI.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/result/UI_1pWIN");
        }
        else if (text.textColor == "p2")
        {
            VODUI.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/result/UI_2pWIN");
        }

    }
}
