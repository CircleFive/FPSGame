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


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("run");
        if (other.gameObject.name == "bullet(Clone)" && this.tag == "BigClystal")
        {
            Debug.Log("BC:Hit");

            BigClystal--;
            if (BigClystal == 0)
            {
                player1Point += 3;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.name == "bullet(Clone)" && this.tag == "Clystal")
        {
            Debug.Log("C:Hit");
            player1Point += 1;
            Destroy(gameObject);
        }
    }

}
