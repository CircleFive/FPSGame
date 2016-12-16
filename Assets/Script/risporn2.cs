//using UnityEngine;
//using System.Collections;

//public class risporn2 : MonoBehaviour {

//    private GameObject objP;
//    private GameObject player;
//    private GameObject player1;
//    private GameObject player2;
//    private GameObject obj;

//    private GameObject C;

//    // 修正　リスポーン位置
//    float[] rispornX = { -3.5f, 0, 3.5f, 4, 3.5f, 0, -3.5f, -4 };
//    float rispornY = 0.5f;
//    float[] rispornZ = { 3.5f, 4, 3.5f, 0, -3.5f, -4, -3.5f, 0 };

//    int nomber;
//    float posX;
//    float posZ;

//    float speed = 5f;

//    [SerializeField]
//    private GameObject bullet;

//    float r_time;

//    bool risOr = false;

//    // Use this for initialization
//    void Start()
//    {
//        //objP = (GameObject)Resources.Load("Prefabs/Player");
//        //if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
//        //{
//        //    player1 = (GameObject)Instantiate(objP, transform.position, transform.rotation);
//        //}
//        //player1.name = "Player1";


//        //if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
//        //{
//        //    player2 = (GameObject)Instantiate(objP, transform.position, transform.rotation);
//        //}
//        //player2.name = "Player2";

//        player1 = GameObject.Find("Player1");
//        player2 = GameObject.Find("Player2");


//        player = this.gameObject;

//        obj = player;

//        obj.AddComponent<MeshRenderer>();
//        obj.AddComponent<SphereCollider>();

//    }

//    // Update is called once per frame
//    void Update()
//    {

//        if (this.transform.position.x - bullet.transform.position.x < 1f && this.transform.position.x - bullet.transform.position.x > -1f
//    && this.transform.position.z - bullet.transform.position.z < 1f && this.transform.position.z - bullet.transform.position.z > -1f)
//        {
//            hitPlayer();
//            risOr = true;
//            ris1();
//        }

//        if (risOr)
//        {
//            ris1();
//        }

//        //    if (player2.transform.position.x < 1f && player2.transform.position.x > -1f
//        //&& player2.transform.position.z < 1f && player2.transform.position.z > -1f)
//        //    {
//        //        //Destroy(gameObject);
//        //        //if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
//        //        //{
//        //            ris2();
//        //       // }
//        //    }



//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "Bullet")
//        {
//            //Destroy(this.gameObject);
//            hitPlayer();
//            risOr = true;
//            ris1();
//        }
//    }

//    public void ris1()
//    {
//        nomber = Random.Range(0, 8);

//        posX = rispornX[nomber];
//        posZ = rispornZ[nomber];


//        if (risTime())
//        {
//            // 修正　y軸
//            this.transform.position = new Vector3(posX, rispornY, posZ);
//            activePlayer();
//            risOr = false;
//        }
//    }
//    //void ris2()
//    //{
//    //    nomber = Random.Range(0, 9);

//    //    posX = rispornX[nomber];
//    //    posZ = rispornZ[nomber];


//    //    if (risTime())
//    //    {
//    //        player2.transform.position = new Vector3(posX, 0, posZ);
//    //        activePlayer();
//    //    }
//    //}
//    public bool risTime()
//    {
//        bool r = false;
//        r_time += Time.deltaTime;


//        if (r_time >= 0.1 && risOr == true)
//        {
//            r = true;
//            r_time = 0;
//        }


//        return r;
//    }

//    void hitPlayer()
//    {
//        obj.GetComponent<MeshRenderer>().enabled = false;
//        obj.GetComponent<SphereCollider>().enabled = false;
//    }

//    void activePlayer()
//    {
//        obj.GetComponent<MeshRenderer>().enabled = true;
//        obj.GetComponent<SphereCollider>().enabled = true;
//    }
//}
