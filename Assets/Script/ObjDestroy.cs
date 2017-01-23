using UnityEngine;
using System.Collections;

public class ObjDestroy : MonoBehaviour {

    // 大きいクリスタルの耐久
    private int BigClystal = 3;


    risporn rpr;

    // ポイント加点
    [SerializeField]
    static private int player1Point; // Player1が獲得したポイント
    [SerializeField]
    static private int player2Point; // Player2が獲得したポイント

    public int Player1Point
    {
        get { return player1Point; }
        set { player1Point = value; }
    }
    public int Player2Point
    {
        get { return player2Point; }
        set { player2Point = value; }
    }



    [SerializeField]
    static private int player1Kill; // Player1が獲得したポイント
    [SerializeField]
    static private int player2Kill; // Player2が獲得したポイント


    private AudioSource audioSource;    // AudioSorceコンポーネント格納用
    [SerializeField]
    private AudioClip sound;        // 効果音の格納用。インスペクタで。



    public int Player1Kill
    {
        get { return player1Kill; }
        set { player1Kill = value; }
    }
    public int Player2Kill
    {
        get { return player2Kill; }
        set { player2Kill = value; }
    }


    [SerializeField]
    private GameObject damageEfect;
    private damage p_damage;



    private PlayerMove _pm1;
    private PlayerMove2 _pm2;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = false;
        rpr = this.GetComponent<risporn>();



        p_damage = damageEfect.GetComponent<damage>();
        if (this.name == "Player1") { _pm1 = this.gameObject.GetComponent<PlayerMove>(); Player1Kill = 0; }
        if (this.name == "Player2") { _pm2 = this.gameObject.GetComponent<PlayerMove2>(); Player2Kill = 0; }
    }


    public string result()
    {
        if (Player1Point + Player1Kill - Player2Kill == Player2Point + Player2Kill - Player1Kill)
        {
            return "DRAW";
        }
        else
        {
            return "VICTORY";
        }

    }

    public int po1()
    {
        return player1Point;
    }
    public int po2()
    {
        return player2Point;
    }



    void OnTriggerEnter(Collider other)
    {

        //if (other.gameObject.name == "bullet(Clone)" && this.tag == "BigClystal")
        //{


        //    BigClystal--;
        //    if (BigClystal == 0)
        //    {
        //        player1Point += 3;
        //        Destroy(gameObject);
        //    }
        //}

        //if (other.gameObject.name == "bullet(Clone)" && this.tag == "Clystal")
        //{

        //    player1Point += 1;
        //    Destroy(gameObject);
        //}

        //// プレイヤー2
        //if (other.gameObject.name == "bullet2(Clone)" && this.tag == "BigClystal")
        //{

        //    BigClystal--;
        //    if (BigClystal == 0)
        //    {
        //        player1Point += 3;
        //        Destroy(gameObject);
        //    }
        //}

        //if (other.gameObject.name == "bullet2(Clone)" && this.tag == "Clystal")
        //{
        //    player1Point += 1;
        //    Destroy(gameObject);
        //}

        // playerのKill、Death
        if (other.gameObject.name == "bullet2(Clone)" && this.tag == "Player1")
        {
            if (!_pm1.NOHIT)
            {
                player2Kill += 1;
                audioSource.PlayOneShot(sound);
                //rpr.GetComponent<risporn>().ris_p = true;
                p_damage._HITCHECK = true;
                p_damage.ARFA = 1f;
                _pm1.DESCHECK1 = true;
                _pm1.NOHIT = true;
            }
        }
        if (other.gameObject.name == "bullet(Clone)" && this.tag == "Player2")
        {
            if (!_pm2.NOHIT)
            {
                player1Kill += 1;
                audioSource.PlayOneShot(sound);
                //rpr.GetComponent<risporn>().ris_p = true;
                p_damage._HITCHECK = true;
                p_damage.ARFA = 1f;
                _pm2.DESCHECK2 = true;
                _pm2.NOHIT = true;
            }
        }
    }

    public int p1_kill()
    {
        return player1Kill;
    }
    public int p2_kill()
    {
        return player2Kill;
    }

}
