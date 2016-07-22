using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour {

    private float m_maxAngle = 90.0f;
    private float m_minAngle = -90.0f;

    //[SerializeField]
    //private GameObject m_target;

    private float m_rotationSpead = 360.0f;

    // Use this for initialization
    private void Awake()
    {
       
        
    }

	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
       
       CameraController();
	}

  private void CameraController()
    {

        ////入力情報
        //float m_turn = Input.GetAxis("Mouse Y");
        ////現在の回転角度を0～360から-180～180に変換
        //float m_rotateY = (transform.eulerAngles.y > 180) ? transform.eulerAngles.y - 360 : transform.eulerAngles.y;
        ////現在の回転角度に入力(m_turn)を加味した回転角度をMathf.Clamp()を使いm_minAngleからm_maxAngle内に収まるようにする
        //float m_angleY = Mathf.Clamp(m_rotateY + m_turn, m_minAngle, m_maxAngle);
        ////回転角度を-180～180から0～360に変換
        //m_angleY = (m_angleY < 0) ? m_angleY + 360 : m_angleY;
        ////回転角度をオブジェクトに適用
        //gameObject.transform.rotation = Quaternion.Euler(m_angleY, 0, 0);

        ////this.transform.rotation = Quaternion.Euler(Input.GetAxis("Mouse Y"), m_target.transform.localEulerAngles.y, 0);
        //m_target.transform.rotation = Quaternion.Euler(Input.GetAxis("Mouse Y"), m_target.transform.localEulerAngles.y, 0);


        //方向転換
        Vector3 m_cameraDirection = new Vector3(0.0f, Input.GetAxisRaw("Mouse Y") * 10, 0.0f);
        m_cameraDirection = transform.TransformDirection(m_cameraDirection);
        //if (m_cameraDirection.magnitude > 0.1f)
        //{
        //    Quaternion m_quaternion = Quaternion.LookRotation(m_cameraDirection);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, m_quaternion, m_rotationSpead * Time.deltaTime);
        //}
        transform.Rotate(Input.GetAxis("Mouse Y") * 50 * -1, 0, 0);

    }
}
