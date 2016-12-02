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
    private GameObject text_p1;
    [SerializeField]
    private GameObject text_p2;

    // コピー用
    private GameObject t_tmp1;
    private GameObject t_tmp2;



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






    void Start () {
        mf_tmp1 = mf_p1;
        mf_tmp2 = mf_p2;

        m_f1_tmp1 = m_f1_p1;
        m_f1_tmp2 = m_f1_p2;

        m_f2_tmp1 = m_f2_p1;
        m_f2_tmp2 = m_f2_p2;

        t_tmp1 = text_p1;
        t_tmp2 = text_p2;

        p1 = player1.transform;
        p2 = player2.transform;
    }

    // Update is called once per frame
    void Update() {
        if (SceneManager.GetActiveScene().name != "Game") return;
        //if (Input.GetKey(KeyCode.Q) || (Input.GetButton("L2button_1"))) m_t(p_name1);
        if (Input.GetKey(KeyCode.Q) || (Input.GetAxis("L2button_1")) <  0.0f) m_t(p_name1);
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
            mf_tmp1.gameObject.SetActive(true);
            t_tmp1.gameObject.SetActive(true);
        }
        else if (player == p_name2)
        {
            mf_tmp2.gameObject.SetActive(true);
            t_tmp2.gameObject.SetActive(true);
        }
    }
    // マップOFF
    void m_f(string player)
    {
        if (player == "p1")
        {
            mf_tmp1.gameObject.SetActive(false);
            t_tmp1.gameObject.SetActive(false);
        }
        else if (player == "p2")
        {
            mf_tmp2.gameObject.SetActive(false);
            t_tmp2.gameObject.SetActive(false);
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
