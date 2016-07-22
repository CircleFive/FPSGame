using UnityEngine;
using System.Collections;

public class killDeath : MonoBehaviour {


    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private GameObject deathObj;

    [SerializeField]
    private GameObject deathObj2;

    private GameObject obj;

    Vector3 p1;
    Vector3 p2;

    objectHp pp;


    void Start () {
        obj = (GameObject)Resources.Load("Prefabs/BigClystal");
        pp = obj.GetComponent<objectHp>();
    }

    void Update () {
        //p1 = player1.transform.position;
        //p2 = player2.transform.position;

        //if (p1.x - deathObj.transform.position.x < 1f && p1.x > -1f - deathObj.transform.position.x
        //&& p1.z - deathObj.transform.position.z < 1f && p1.z - deathObj.transform.position.z > -1f)
        //{
        //    p1Death();
        //}
        //if (p2.x - deathObj2.transform.position.x < 1f && p2.x > -1f - deathObj2.transform.position.x
        //&& p2.z - deathObj2.transform.position.z < 1f && p2.z - deathObj2.transform.position.z > -1f)
        //{
        //    p2Death();
        //}


    }

    public  void p1Death()
    {
        if (pp.Player1Point > 0)
        {
            pp.Player1Point--;
        }
        pp.Player2Point++;
        player1.transform.position = new Vector3(5, 0, 0);
    }
    public void p2Death()
    {
        pp.Player1Point++;
        if (pp.Player2Point > 0)
        {
            pp.Player2Point--;
        }
        player2.transform.position = new Vector3(-5, 0, 0);

    }

}
