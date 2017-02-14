using UnityEngine;
using System.Collections;

public class FirstPersonCamera2 : MonoBehaviour {
    [SerializeField]
    private Transform m_mainCamera;
    [SerializeField]
    private GameObject m_zoomOutPotision;
    [SerializeField]
    private Transform m_zoomInPotision;

    [SerializeField]
    private Transform m_cameraPotision;               //目線用のカメラ


    [SerializeField]
    private float cameraRotateLimit;
    [SerializeField]
    private bool cameraRotForward;                    //マウスを上で上を向く場合はtrue,マウスを上で下を向く場合はfalse

    private Quaternion initCameraRot;                 //カメラの角度の初期値
    private float m_rotationSpead = 180.0f;
    PlayerMove2 player;

    [SerializeField]
    private Transform m_gun;                          //銃オブジェクト
    [SerializeField]
    private Transform m_spine;                        //プレイヤーの背のボーン指定
    //[SerializeField]
    //private Transform m_rightHand;           //PlayerModelの右手
    //[SerializeField]
    //private Transform m_rightShoulder;
    //[SerializeField]
    //private Transform m_leftHand;            //PlayerModelの左手
    //[SerializeField]
    //private Transform m_leftShoulder;

    [SerializeField]
    private Transform m_centerPotision;

    //[SerializeField]
    //private GameObject m_reticle;


    // Use this for initialization
    private void Start()
    {
        //m_reticle.SetActive(false);
        player = GetComponent<PlayerMove2>();
        initCameraRot = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //常にMainCameraは目線のPotisionにセットされる
        m_mainCamera.transform.position = m_cameraPotision.position;
        if (!player.DESCHECK2)
        {
            Direction();
        }
        //if (Input.GetButton("L1button_1"))
        //{

        //    if (m_zoomInPotision.position.z > m_cameraPotision.position.z)
        //    {
        //        m_cameraPotision.position += m_cameraPotision.forward * 0.1f;
        //        m_reticle.SetActive(true);
        //    }

        //}

        //if (Input.GetButtonUp("L1button_1"))
        //{
        //    m_cameraPotision.position = m_zoomOutPotision.transform.position;
        //    m_reticle.SetActive(false);
        //}



    }

    private void Direction()
    {
        //左右方向転換
        Vector3 m_playerDirection = new Vector3(Input.GetAxisRaw("Mouse X2") * 10, 0.0f, 0.0f);

        m_playerDirection = player.transform.TransformDirection(m_playerDirection);

        //右スティックを横に少し倒したときの感度
        if (m_playerDirection.magnitude > 0.03f || m_playerDirection.magnitude < -0.03f)
        {
            Quaternion m_quaternion = Quaternion.LookRotation(m_playerDirection);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, m_quaternion, m_rotationSpead * Time.deltaTime / 2);
        }
        //右スティックを横に全開に倒したときの感度
        if (m_playerDirection.magnitude > 5.1f || m_playerDirection.magnitude < -5.1f)
        {
            Quaternion m_quaternion = Quaternion.LookRotation(m_playerDirection);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, m_quaternion, m_rotationSpead * Time.deltaTime);
        }

        //上下への視点移動
        float xRotate = Input.GetAxis("Mouse Y2");

        if (cameraRotForward)
        {
            xRotate *= -1;
        }
        Quaternion cameraRotate = m_mainCamera.rotation * Quaternion.Euler(xRotate * m_rotationSpead * Time.deltaTime, 0, 0);

        //カメラの角度が限界角度を超えてなければカメラの角度を更新する
        if (cameraRotateLimit > Quaternion.Angle(initCameraRot, Quaternion.Euler(cameraRotate.eulerAngles.x, 0, 0)))
        {
            m_mainCamera.rotation = cameraRotate;
            m_gun.rotation = cameraRotate;
        }

    }

    //Playerモデルの上半身の角度を変える
    void LateUpdate()
    {
        if (!player.DESCHECK2)
            m_spine.eulerAngles = new Vector3(m_mainCamera.eulerAngles.x, m_spine.eulerAngles.y, 0);
    }
    //void LateUpdate()
    //{

    //    //RaycastHit m_hit;

    //    //if (Physics.Raycast(m_cameraPotision.position, m_cameraPotision.forward, out m_hit))
    //    //{
    //    //    m_gun.transform.LookAt(m_hit.transform.position);
    //    //}

    //     m_gun.transform.LookAt(m_centerPotision);

    //}

}
