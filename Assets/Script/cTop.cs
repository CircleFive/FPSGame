using UnityEngine;
using System.Collections;

public class cTop : MonoBehaviour
{

    private PlayerMove _pm1;
    private PlayerMove2 _pm2;

    private GameObject p1;
    private GameObject p2;

    void Start()
    {
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        if (p1.name == "Player1") { _pm1 = p1.GetComponent<PlayerMove>();}
        if (p2.name == "Player2") { _pm2 = p2.GetComponent<PlayerMove2>();}
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "CrouchTop_p1")
        {
            _pm1.CROUCHTOP = true;
        }
        if (other.gameObject.tag == "CrouchTop_p2")
        {
            _pm2.CROUCHTOP = true;
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "CrouchTop_p1")
        {
            _pm1.CROUCHTOP = true;
        }
        if (other.gameObject.name == "CrouchTop_p2")
        {
            _pm2.CROUCHTOP = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CrouchTop_p1" && this.tag == "CrouchTop")
        {
            _pm1.CROUCHTOP = false;
        }
        if (other.gameObject.tag == "CrouchTop_p2" && this.tag == "CrouchTop")
        {
            _pm2.CROUCHTOP = false;
        }

    }

}
