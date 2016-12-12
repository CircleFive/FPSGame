using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour {

    [SerializeField]
    private GameObject m_mainCamera;
    [SerializeField]
    private GameObject m_zoomOutPotision;
    [SerializeField]
    private Transform m_zoomInPotision;

    [SerializeField]
    private Transform m_cameraPotision;     //目線用のカメラ
    [SerializeField]
    private GameObject m_gun;               //銃オブジェクト
    [SerializeField]
    private Transform m_rightArm;           //PlayerModelの右腕
    [SerializeField]
    private Transform m_rightShoulder;
    [SerializeField]
    private Transform m_leftArm;            //PlayerModelの左腕
    [SerializeField]
    private Transform m_leftShoulder;

    [SerializeField]
    private Transform m_centerPotision;     

    [SerializeField]
    private GameObject m_reticle;


    // Use this for initialization
    private void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        //常にMainCameraは目線のPotisionにセットされる
        m_mainCamera.transform.position = m_cameraPotision.position;

        if (Input.GetButton("L1button_1"))
        {
            
            if (m_zoomInPotision.position.z > m_cameraPotision.position.z)
            {
                m_cameraPotision.position += m_cameraPotision.forward * 0.1f;
                Debug.Log("Max");
            }

        }

        if (Input.GetButtonUp("L1button_1"))
        {
            m_cameraPotision.position = m_zoomOutPotision.transform.position;
        }

        RaycastHit m_hit;

        if (Physics.Raycast(m_cameraPotision.position, m_cameraPotision.forward,out m_hit))
        {
            m_gun.transform.LookAt(m_hit.point);
        }

    }


    //void LateUpdate()
    //{
    //    m_leftArm.LookAt(m_centerPotision);
    //    m_rightArm.LookAt(m_centerPotision);
    //    m_rightShoulder.LookAt(m_centerPotision);
    //    m_leftShoulder.LookAt(m_centerPotision);

    //    m_gun.transform.LookAt(m_centerPotision);
    //}
    
}
