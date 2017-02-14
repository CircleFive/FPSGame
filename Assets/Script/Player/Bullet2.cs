using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bullet2 : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform m_muzzle;

    private float m_speed = 3000.0f;

    private int playerNum = 1;

    private int gun_num;

    private int BULLET = 1;

    killDeath kk;
    redGage RG;
    [SerializeField]
    private GameObject red;



    private AudioSource audioSource;    // AudioSorceコンポーネント格納用
    [SerializeField]
    private AudioClip sound;        // 効果音の格納用。インスペクタで。


    //private int bulletNumber = 3;

    // Use this for initialization
    void Start()
    {
        kk = GetComponent<killDeath>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = false;
        if (SceneManager.GetActiveScene().name == "Game")
        {
            RG = red.GetComponent<redGage>();
            //gun_num = BULLET;
        }
        if (SceneManager.GetActiveScene().name == "Title")
            gun_num = BULLET;

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetButtonDown("Fire1_2") && SceneManager.GetActiveScene().name == "Title")
        {
            t_Shot();

        }

    }

    void t_Shot()
    {


        if (gun_num == 0) { return; }
        GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
        bullets.transform.position = m_muzzle.position;
        bullets.transform.rotation = m_muzzle.rotation;
        Vector3 m_force;
        m_force = this.gameObject.transform.forward * m_speed;
        bullets.GetComponent<Rigidbody>().AddForce(m_force);
        audioSource.PlayOneShot(sound);
        gun_num--;
        if (gun_num == 0) { StartCoroutine("reChargeGun"); }
        Destroy(bullets, 3);

    }
    public void Shot(int rb)
    {


        if (rb == 0) { return; }
        GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
        bullets.transform.position = m_muzzle.position;
        bullets.transform.rotation = m_muzzle.rotation;
        Vector3 m_force;
        m_force = bullets.transform.forward * m_speed;
        bullets.GetComponent<Rigidbody>().AddForce(m_force);
        audioSource.PlayOneShot(sound);

        //gun_num--;
        //if (gun_num == 0) { StartCoroutine("reChargeGun"); }
        Destroy(bullets, 3);

    }

    IEnumerator reChargeGun()
    {
        yield return new WaitForSeconds(3.0f);      // 3秒、処理を待機.
        gun_num = BULLET;                      // 銃弾装填.
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            //Debug.Log("Player1Death");
            kk.p1Death();
            Destroy(other.gameObject);
        }
    }
}
