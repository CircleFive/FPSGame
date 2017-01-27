using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class risporn : MonoBehaviour
{


    private GameObject objP;
    private GameObject player1;
    private GameObject player2;
    private GameObject obj;

    private PlayerMove _pm1;
    private PlayerMove2 _pm2;

    private List<Transform> pp;

    private Transform[] ppp;

    [SerializeField]
    private GameObject Flore_points;

    private float g_check = -0.5f;


    private Transform[] trans;

    float r_time;

    bool risOr = false;

    bool set = true;

    private int RISPOINTCOUNT = 0;
    Transform Flore_point;


    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            foreach (Transform Flore_Count in Flore_points.transform)
            {
                RISPOINTCOUNT++;
            }
            ppp = new Transform[RISPOINTCOUNT];
            RISPOINTCOUNT = 0;
            foreach (Transform Flore_point in Flore_points.transform)
            {
                ppp[RISPOINTCOUNT] = Flore_point;
                RISPOINTCOUNT++;
            }
        }
    }

    // Use this for initialization
    void Start()
    {

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        obj = this.gameObject;

        //Invoke("StartDray", 1.5f);

        if (this.gameObject.name == player1.name) _pm1 = this.gameObject.GetComponent<PlayerMove>();
        if (this.gameObject.name == player2.name) _pm2 = this.gameObject.GetComponent<PlayerMove2>();

    }

    // Update is called once per frame
    void Update()
    {

        if (this.name == "Player1")
        {
            if (_pm1.RISBOOL)/* || _pm2.RISBOOL*/
                ris();
        }
        else if (this.name == "Player2")
        {
            if (_pm2.RISBOOL)/* || _pm2.RISBOOL*/
                ris();
        }

        if (obj.transform.position.y - 0.9f < g_check)
            ground();
    }


    void ris()
    {
        Transform pos;
        int num;
        num = Random.Range(0, RISPOINTCOUNT);

        pos = ppp[num].transform;

        obj.transform.position = pos.position;
        obj.transform.rotation = pos.rotation;

        if (this.name == "Player1") _pm1.RISBOOL = false;
        if (this.name == "Player2") _pm2.RISBOOL = false;
    }

    void ground()
    {
        obj.transform.position = new Vector3(obj.transform.position.x, 0f, obj.transform.position.z);
    }



}
