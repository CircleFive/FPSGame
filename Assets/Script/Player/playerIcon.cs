using UnityEngine;
using System.Collections;

public class playerIcon : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    private Transform _thisTmp;

    private Vector3 aaa;
    private float m_rotationSpead = 360.0f;

    private Quaternion bbb;

    // Use this for initialization
    void Start () {
        _thisTmp = this.gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        posUpdate();
	}

    void posUpdate()
    {
        //aaa = new Vector3(_thisTmp.position.x, 4, _thisTmp.position.z);

        bbb = new Quaternion(90, player.transform.rotation.y, 0, 1);
        _thisTmp.transform.position = player.transform.position;
        _thisTmp.transform.rotation = bbb;
        //_thisTmp.transform.localRotation = player.transform.localRotation;

        //Direction();
    }

    //private void Direction()
    //{
    //    //左右方向転換
    //    Vector3 m_playerDirection = new Vector3(Input.GetAxis("Mouse X1") * 10, 0.0f, 0.0f);
    //    m_playerDirection = transform.TransformDirection(m_playerDirection);
    //    if (m_playerDirection.magnitude > 0.1f)
    //    {
    //        Quaternion m_quaternion = Quaternion.LookRotation(m_playerDirection);
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, m_quaternion, m_rotationSpead * Time.deltaTime);
    //    }


    //}


}
