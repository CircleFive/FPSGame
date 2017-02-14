using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mapChenge : MonoBehaviour {

    // マップフレーム
    [SerializeField]
    private Camera mf_p1;
    [SerializeField]
    private Camera mf_p2;

    // コピー用
    private Camera mf_tmp1;
    private Camera mf_tmp2;


    // 1F
    [SerializeField]
    private SpriteRenderer m_f1_p1;
    [SerializeField]
    private SpriteRenderer m_f1_p2;

    // コピー用
    private SpriteRenderer m_f1_tmp1;
    private SpriteRenderer m_f1_tmp2;

    // 2F
    [SerializeField]
    private SpriteRenderer m_f2_p1;
    [SerializeField]
    private SpriteRenderer m_f2_p2;

    // コピー用
    private SpriteRenderer m_f2_tmp1;
    private SpriteRenderer m_f2_tmp2;


    [SerializeField]
    private GameObject player1;
    private Transform p1;

    [SerializeField]
    private GameObject player2;
    private Transform p2;


    private string p_name1 = "p1";
    private string p_name2 = "p2";

    private string mState1 = "F1";
    private string mState2 = "F1";




    private Camera miniCamera1;
    private Rect initViewport1;
    private m_CameraController updateViewport1;
    private Camera miniCamera2;
    private Rect initViewport2;
    private m_CameraController updateViewport2;


    private Image reticle1;
    private Image reticle2;


    void Start () {
        miniCamera1 = mf_p1.GetComponent<Camera>();
        initViewport1 = miniCamera1.rect;
        updateViewport1 = mf_p1.GetComponent<m_CameraController>();

        miniCamera2 = mf_p2.GetComponent<Camera>();
        initViewport2 = miniCamera2.rect;
        updateViewport2 = mf_p2.GetComponent<m_CameraController>();

        reticle1 = GameObject.Find("reticle1").GetComponent<Image>();
        reticle2 = GameObject.Find("reticle2").GetComponent<Image>();



        mf_tmp1 = mf_p1;
        mf_tmp2 = mf_p2;

        m_f1_tmp1 = m_f1_p1;
        m_f1_tmp2 = m_f1_p2;

        m_f2_tmp1 = m_f2_p1;
        m_f2_tmp2 = m_f2_p2;


        p1 = player1.transform;
        p2 = player2.transform;
    }

    // Update is called once per frame
    void Update() {
        if (SceneManager.GetActiveScene().name != "Game") return;
        if (Input.GetKey(KeyCode.Q) || (Input.GetButton("L2button_1"))) m_t(p_name1);
        // if (Input.GetKey(KeyCode.Q) || (Input.GetAxis("L2button_1")) <  0.0f) m_t(p_name1);
        else m_f(p_name1);
        if (Input.GetKey(KeyCode.B) || (Input.GetButton("L2button_2"))) m_t(p_name2);
        else m_f(p_name2);

        if (p1.transform.position.y > 3.35f) { mState1 = "F2"; m_Chenge(p_name1); }
        else { mState1 = "F1";m_Chenge(p_name1); }

        if (p2.transform.position.y > 3.35f) { mState2 = "F2"; m_Chenge(p_name2); }
        else { mState2 = "F1"; m_Chenge(p_name2); }
    }

    // マップON
    void m_t(string player)
    {
        if (player == p_name1)
        {
            reticle1.enabled = false;
            miniCamera1.rect = updateViewport1.getChegeRect();
        }
        else if (player == p_name2)
        {
            reticle2.enabled = false;
            miniCamera2.rect = updateViewport2.getChegeRect();
        }
    }
    // マップOFF
    void m_f(string player)
    {
        if (player == "p1")
        {
            reticle1.enabled = true;
            miniCamera1.rect = initViewport1;
        }
        else if (player == "p2")
        {
            reticle2.enabled = true;
            miniCamera2.rect = initViewport2;
        }

    }

    // １階と２階の切り替え
    void m_Chenge(string player)
    {
        if (player == p_name1)
        {
            if(mState1 == "F1")
            {
                m_f1_tmp1.gameObject.SetActive(true);
                m_f2_tmp1.gameObject.SetActive(false);
            }
            else if (mState1 == "F2")
            {
                m_f2_tmp1.gameObject.SetActive(true);
                m_f1_tmp1.gameObject.SetActive(false);

            }
        }
        else if (player == p_name2)
        {
            if (mState2 == "F1")
            {
                m_f1_tmp2.gameObject.SetActive(true);
                m_f2_tmp2.gameObject.SetActive(false);
            }
            else if (mState2 == "F2")
            {
                m_f2_tmp2.gameObject.SetActive(true);
                m_f1_tmp2.gameObject.SetActive(false);

            }
        }

    }

}
