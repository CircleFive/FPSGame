using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountStart : MonoBehaviour {

    [SerializeField]
    private Image _imageCountdown;
    [SerializeField]
    private Image _imageGameSet;
    private Image _IGSTMP;

    private Sprite[] CountDown_UI;

    private float arfa;
    private Vector4 mask;

    private string GameState = "GameCount";

    public string _GAMESTATE
    {
        get { return GameState; }
        set { GameState = value; }
    }

    private bool maskStart = false;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private GameObject thisGameObject;
    private GameObject _thisScript;

    [SerializeField]
    private GameObject b_Gage;
    [SerializeField]
    private GameObject r_Gage;

    private limitTime _limitTime;

    // Use this for initialization
    void Start () {
        _thisScript = thisGameObject;
        scriptOFF();
        mask = _imageCountdown.color;

        arfa = _imageCountdown.color.a;

        _thisScript = this.gameObject;

        _IGSTMP = _imageGameSet;

        _limitTime = _thisScript.GetComponent<limitTime>();

        StartCoroutine(CountdownCoroutine());



    }

    IEnumerator CountdownCoroutine()
    {
        _imageCountdown.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/GameStart/UI3");
        yield return new WaitForSeconds(1.0f);

        _imageCountdown.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/GameStart/UI2");
        yield return new WaitForSeconds(1.0f);

        _imageCountdown.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/GameStart/UI1");
        yield return new WaitForSeconds(1.0f);

        _imageCountdown.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/GameStart/UIGO");
        GameState = "GameStart";
        scriptON();
        yield return new WaitForSeconds(1.0f);
        maskStart = true;

    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (maskStart) mask_GO();
            if (_GAMESTATE == "GameSet")
                StartCoroutine(GameSetToResult());
        }
    }

    void mask_GO()
    {
        if (arfa < 0) return;
        arfa -= Time.deltaTime;
        mask.w = arfa;
        _imageCountdown.color = mask;
    }

    void scriptOFF()
    {
        player1.transform.GetComponent<PlayerMove>().enabled = false;
        player1.transform.GetComponent<Bullet>().enabled = false;
        player2.transform.GetComponent<PlayerMove2>().enabled = false;
        player2.transform.GetComponent<Bullet2>().enabled = false;
        b_Gage.transform.GetComponent<blueGage>().enabled = false;
        r_Gage.transform.GetComponent<redGage>().enabled = false;
        _thisScript.transform.GetComponent<limitTime>().enabled = false;
        _thisScript.transform.GetComponent<mapChenge>().enabled = false;
    }


    void scriptON()
    {
        player1.transform.GetComponent<PlayerMove>().enabled = true;
        player1.transform.GetComponent<Bullet>().enabled = true;
        player2.transform.GetComponent<PlayerMove2>().enabled = true;
        player2.transform.GetComponent<Bullet2>().enabled = true;
        b_Gage.transform.GetComponent<blueGage>().enabled = true;
        r_Gage.transform.GetComponent<redGage>().enabled = true;
        _thisScript.transform.GetComponent<limitTime>().enabled = true;
        _thisScript.transform.GetComponent<mapChenge>().enabled = true;

    }
    IEnumerator GameSetToResult()
    {
        scriptOFF();
        _IGSTMP.gameObject.SetActive(true);
        GameState = "ToResult";
        yield return new WaitForSeconds(5.0f);
        _limitTime.ToRESULT();
    }

}
