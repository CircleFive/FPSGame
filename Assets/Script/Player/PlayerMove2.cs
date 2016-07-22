using UnityEngine;
using System.Collections;

public class PlayerMove2 : MonoBehaviour {

    public float m_moveSpead;
    public float m_jumpPower;
    private float m_rotationSpead = 360.0f;

    private Vector3 m_move = Vector3.zero;

    private float m_speed = 5.0f;

    private const float GRAVITY = 9.8f;

    CharacterController m_characterController;
    Animator m_animator;
    private GameObject m_camera;


    // Use this for initialization
    void Start()
    {
        m_camera = GameObject.Find("/Player/Main Camera");
        m_characterController = GetComponent<CharacterController>();
        m_animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        // Direction();
    }
    private void Move()
    {
        //移動処理
        float y = m_move.y;
        //m_move = new Vector3(Input.GetAxis("Horizontar"), 0, Input.GetAxis("Verticar"));
        //m_move = transform.TransformDirection(m_move);

        // ジャンプ/重力処理
        m_move.y += y;
        if (m_characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                m_move.y = m_jumpPower;
            }
        }
        m_move.y -= GRAVITY * Time.deltaTime;//重力を代入


        if (Input.GetKey(KeyCode.A))
        {
            // this.transform.position += new Vector3(-5 * Time.deltaTime, 0, 0);
            m_move = new Vector3(-1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //this.transform.position += new Vector3(5 * Time.deltaTime, 0, 0);
            m_move = new Vector3(1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            //this.transform.position += new Vector3(0, 0, 5 * Time.deltaTime);
            m_move = new Vector3(0, 0, 1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.transform.position += new Vector3(0, 0, -5 * Time.deltaTime);
            m_move = new Vector3(0, 0, -1 * Time.deltaTime);
        }


        //  move = transform.TransformDirection(move);

        m_characterController.Move(m_move);
        m_animator.SetFloat("Speed", m_characterController.velocity.magnitude);





        //gameObject.transform.position = new Vector3(m_camera.transform.position.x, m_camera.transform.position.y, m_camera.transform.position.z);
    }

    private void Direction()
    {
        //方向転換
        Vector3 m_playerDirection = new Vector3(Input.GetAxisRaw("Mouse X") * 10, 0.0f, 0.0f);
        m_playerDirection = transform.TransformDirection(m_playerDirection);
        if (m_playerDirection.magnitude > 0.1f)
        {
            Quaternion m_quaternion = Quaternion.LookRotation(m_playerDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_quaternion, m_rotationSpead * Time.deltaTime);
        }

    }
}
