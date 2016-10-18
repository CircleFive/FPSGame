using UnityEngine;
using System.Collections;

public class ObjDestroy : MonoBehaviour {

    // 大きいクリスタルの耐久
    private int BigClystal = 3;



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



    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = false;
    }


    public string result()
    {
        if (Player1Point == Player2Point)
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

        if (other.gameObject.name == "bullet(Clone)" && this.tag == "BigClystal")
        {


            BigClystal--;
            if (BigClystal == 0)
            {
                player1Point += 3;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.name == "bullet(Clone)" && this.tag == "Clystal")
        {

            player1Point += 1;
            Destroy(gameObject);
        }

        // プレイヤー2
        if (other.gameObject.name == "bullet2(Clone)" && this.tag == "BigClystal")
        {

            BigClystal--;
            if (BigClystal == 0)
            {
                player1Point += 3;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.name == "bullet2(Clone)" && this.tag == "Clystal")
        {
            player1Point += 1;
            Destroy(gameObject);
        }

        // playerのKill、Death
        if (other.gameObject.name == "bullet2(Clone)" && this.tag == "Player1")
        {
            player2Kill += 1;
            audioSource.PlayOneShot(sound);
        }
        if (other.gameObject.name == "bullet(Clone)" && this.tag == "Player2")
        {
            player1Kill += 1;
            audioSource.PlayOneShot(sound);
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
