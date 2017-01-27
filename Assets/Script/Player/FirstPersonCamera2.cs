using UnityEngine;
using System.Collections;

public class FirstPersonCamera2 : MonoBehaviour {
    [SerializeField]
    private GameObject m_mainCamera;
    [SerializeField]
    private GameObject m_zoomOutPotision;
    [SerializeField]
    private Transform m_zoomInPotision;

    [SerializeField]
    private Transform m_cameraPotision;     //目線用のカメラ
    //[SerializeField]
    //private GameObject m_gun;               //銃オブジェクト
    //[SerializeField]
    //private Transform m_rightHand;           //PlayerModelの右手
    //[SerializeField]
    //private Transform m_rightShoulder;
    //[SerializeField]
    //private Transform m_leftHand;            //PlayerModelの左手
    //[SerializeField]
    //private Transform m_leftShoulder;

    //[SerializeField]
    //private Transform m_centerPotision;

    //[SerializeField]
    //private GameObject m_reticle;


    // Use this for initialization
    private void Start()
    {
        //m_reticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //常にMainCameraは目線のPotisionにセットされる
        m_mainCamera.transform.position = new Vector3(m_mainCamera.transform.position.x, m_cameraPotision.position.y, m_mainCamera.transform.position.z);

        //if (Input.GetButton("L1button_2"))
        //{

        //    if (m_zoomInPotision.position.z > m_cameraPotision.position.z)
        //    {
        //        m_cameraPotision.position += m_cameraPotision.forward * 0.1f;
        //        m_reticle.SetActive(true);
        //    }

        //}

        //if (Input.GetButtonUp("L1button_2"))
        //{
        //    m_cameraPotision.position = m_zoomOutPotision.transform.position;
        //    m_reticle.SetActive(false);
        //}



    }


    void LateUpdate()
    {

        //RaycastHit m_hit;

        //if (Physics.Raycast(m_cameraPotision.position, m_cameraPotision.forward, out m_hit))
        //{
        //    m_gun.transform.LookAt(m_hit.transform.position);
        //}

        // m_gun.transform.LookAt(m_centerPotision);

    }

}
