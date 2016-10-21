using UnityEngine;
using System.Collections;

public class risporn : MonoBehaviour
{


    private GameObject objP;
    private GameObject player1;
    private GameObject player2;
    private GameObject obj;

    [SerializeField]
    private GameObject[] points;

    private Transform[] trans;

    public bool ris_p = false;

    // 修正　リスポーン位置
    float[] rispornX = { -3.5f, 0, 3.5f, 4, 3.5f, 0, -3.5f, -4 };
    float rispornY = 0.5f;
    float[] rispornZ = { 3.5f, 4, 3.5f, 0, -3.5f, -4, -3.5f, 0 };

    int nomber;
    float posX;
    float posZ;


    float r_time;

    bool risOr = false;


    //void limit()
    //{
    //    for (int i = 0; i < points.Length; i++)
    //    {

    //        trans[i] = points[i].transform;
    //        //trans[i] = points[i].transform;
    //    }

    //}


    // Use this for initialization
    void Start()
    {

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        obj = this.gameObject;
        
        obj.AddComponent<MeshRenderer>();
        obj.AddComponent<CapsuleCollider>();

        //Invoke("limit", 1f);

    }

    // Update is called once per frame
    void Update()
    {


        //    if (player1.transform.position.x - player2.transform.position.x < 1f && player1.transform.position.x - player2.transform.position.x > -1f
        //&& player1.transform.position.z - player2.transform.position.z < 1f && player1.transform.position.z - player2.transform.position.z > -1f)
        //    {
        //        hitPlayer();
        //        risOr = true;
        //        ris1();
        //    }

        //if (risOr)
        //{
        //    ris1();
        //}

        //    if (player2.transform.position.x < 1f && player2.transform.position.x > -1f
        //&& player2.transform.position.z < 1f && player2.transform.position.z > -1f)
        //    {
        //        //Destroy(gameObject);
        //        //if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
        //        //{
        //            ris2();
        //       // }
        //    }


        if(ris_p)
        ris();

    }


    void ris()
    {
        int num;
        num = Random.Range(0, 4);

        obj.transform.position = points[num].transform.position;
        ris_p = false;
    }

    void OnTriggerEnter(Collider other)
    {
        hitPlayer();
        risOr = true;
        ris1();

    }

    void ris1()
    {

        nomber = Random.Range(0, 8);

        posX = rispornX[nomber];
        posZ = rispornZ[nomber];


        if (risTime())
        {
            // 修正　y軸
            obj.transform.position = new Vector3(posX, rispornY, posZ);
            activePlayer();
            risOr = false;
        }
    }
    //void ris2()
    //{
    //    nomber = Random.Range(0, 9);

    //    posX = rispornX[nomber];
    //    posZ = rispornZ[nomber];


    //    if (risTime())
    //    {
    //        player2.transform.position = new Vector3(posX, 0, posZ);
    //        activePlayer();
    //    }
    //}
    public bool risTime()
    {
        bool r = false;
        r_time += Time.deltaTime;


        if (r_time >= 2 && risOr == true)
        {
            r = true;
            r_time = 0;
        }


        return r;
    }

    void hitPlayer()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }

    void activePlayer()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }

}
