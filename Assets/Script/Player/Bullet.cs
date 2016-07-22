using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform m_muzzle;

    private float m_speed = 3000.0f;

    private int playerNum = 1;

    private int gun_num;

    private int BULLET = 1;

    killDeath kk;

    //private int bulletNumber = 3;

	// Use this for initialization
	void Start () {
        kk = GetComponent<killDeath>();
        gun_num = BULLET;
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
            
        }      

	}

    void Shot()
    {
        if (gun_num == 0) { return; }

        GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
        bullets.transform.position = m_muzzle.position;
        bullets.transform.rotation = m_muzzle.rotation;
        Vector3 m_force;
        m_force = this.gameObject.transform.forward * m_speed;
        bullets.GetComponent<Rigidbody>().AddForce(m_force);

        gun_num--;
        if (gun_num == 0) { StartCoroutine("reChargeGun"); }
        Destroy(bullets,3);
       
    }

    IEnumerator reChargeGun()
    {
        yield return new WaitForSeconds(3.0f);      // 3秒、処理を待機.
        gun_num = BULLET;                      // 銃弾装填.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player2")
        {
            Debug.Log("Player2Death");
            kk.p2Death();
            Destroy(other.gameObject);
        }
    }

}
