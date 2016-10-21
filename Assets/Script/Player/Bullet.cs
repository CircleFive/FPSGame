using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform m_muzzle;

    private float m_speed = 3000.0f;

    private int playerNum = 1;

    private int gun_num;

    public int BULLET = 5;

    int bullets = 5;

    killDeath kk;
    blueGage BG;
    [SerializeField]
    private GameObject blue;

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
            BG = blue.GetComponent<blueGage>();

        }
        if (SceneManager.GetActiveScene().name == "Title")
            gun_num = BULLET;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1_1") && SceneManager.GetActiveScene().name == "Title")
        {
            t_Shot();

        }

    }

    public void Shot(int bb)
    {


        if (bb == 0) { return; }
        GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
        bullets.transform.position = m_muzzle.position;
        bullets.transform.rotation = m_muzzle.rotation;
        Vector3 m_force;
        m_force = this.gameObject.transform.forward * m_speed;
        bullets.GetComponent<Rigidbody>().AddForce(m_force);
        audioSource.PlayOneShot(sound);
        //gun_num--;
        //if (gun_num == 0) { StartCoroutine("reChargeGun"); }
        Destroy(bullets,3);
       
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

    IEnumerator reChargeGun()
    {
        yield return new WaitForSeconds(2.0f);      // 3秒、処理を待機.
        gun_num = BULLET;                      // 銃弾装填.
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player2")
    //    {
    //        Debug.Log("Player2Death");
    //        kk.p2Death();
    //        Destroy(other.gameObject);
    //    }

    //}

}
