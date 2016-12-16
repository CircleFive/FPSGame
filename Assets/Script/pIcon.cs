using UnityEngine;
using System.Collections;

public class pIcon : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    private Transform p;

    private GameObject pi;

    Quaternion aaa;
    private float m_rotationSpead = 360.0f;
    private Vector3 pPosTmp = Vector3.zero;

    private float m_speed = 1000f;

    private Transform tmp;
    private bool cameraRotForward;//マウスを上で上を向く場合はtrue,マウスを上で下を向く場合はfalse

    // Use this for initialization
    void Start () {
        p = player.transform;
        pi = this.gameObject;
        aaa = pi.transform.localRotation;
        pi.transform.localRotation = new Quaternion(0, 0, p.localRotation.y, 0);

        //pPosTmp = p.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        //pi.transform.localRotation = Quaternion.Euler(0, 0, p.forward.z);
        //Direction();
        p_posCheck();
        p_rotCheck();
    }

    void p_posCheck()
    {
        //pi.transform.position = pPosTmp;

        pPosTmp = new Vector3(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"), 0);
        pPosTmp = transform.TransformDirection(pPosTmp);


        pi.transform.position += pPosTmp * Time.deltaTime * m_speed;
    }

    void p_rotCheck()
    {
        //aaa = new Quaternion(0, 0, p.localRotation.y, 0);
        //pi.transform.localRotation = Quaternion.Euler(0, 0, (360 - (p.localRotation.y * 360)));

        //pi.transform.rotation = new Quaternion(0, 0, p.rotation.y, 0);
        //pi.transform.rotation = p_rot();
        //pi.transform.rotation = new Quaternion(90, p.rotation.y, 0, 0);
        if (pi.transform.rotation.y < 0 || pi.transform.localRotation.y < 0)
        {

            pi.transform.localRotation = aaa;
        }
        pi.transform.localRotation = Quaternion.Euler(90, (p.rotation.y * 180), 0);
        //pi.transform.localRotation = Quaternion.Euler(90, p.rotation.y, 0);
        //pi.transform.rotation = Quaternion.Euler(0, 0, (p.localRotation.y * 360));
    }

    Quaternion p_rot()
    {
        Quaternion trans = new Quaternion();
        Vector3 m_playerDirection = new Vector3(Input.GetAxis("Mouse X1") * 10, 0.0f, 0.0f);
        m_playerDirection = transform.TransformDirection(m_playerDirection);
        if (m_playerDirection.magnitude > 0.1f)
        {
            Quaternion m_quaternion = Quaternion.LookRotation(m_playerDirection);
            trans = Quaternion.RotateTowards(transform.rotation, m_quaternion, m_rotationSpead * Time.deltaTime);
        }

        return trans;
    }
    private void Direction()
    {
        //左右方向転換
        Vector3 m_playerDirection = new Vector3(Input.GetAxis("Mouse X1") * 0, 0.0f, 10f);
        m_playerDirection = pi.transform.TransformDirection(m_playerDirection);
        if (m_playerDirection.magnitude > 0.1f)
        {
            Quaternion m_quaternion = Quaternion.LookRotation(m_playerDirection);
            pi.transform.rotation = Quaternion.RotateTowards(pi.transform.rotation, m_quaternion, m_rotationSpead * Time.deltaTime);
        }

        ////上下への視点移動
        //float xRotate = Input.GetAxis("Mouse Y1");
        //if (cameraRotForward)
        //{
        //    xRotate *= -1;
        //}

    }

}
