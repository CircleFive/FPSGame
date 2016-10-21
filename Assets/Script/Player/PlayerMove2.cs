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

    [SerializeField]
    private float cameraRotateLimit;
    [SerializeField]
    private bool cameraRotForward;//マウスを上で上を向く場合はtrue,マウスを上で下を向く場合はfalse

    private Quaternion initCameraRot;

    private Transform m_camera;

    // Use this for initialization
    void Start()
    {
        m_camera = GetComponentInChildren<Camera>().transform;
        m_characterController = GetComponent<CharacterController>();
        m_animator = GetComponentInChildren<Animator>();
        initCameraRot = m_camera.rotation;

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Direction();
    }
    private void Move()
    {
        //移動処理
        float y = m_move.y;
        m_move = new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2"));


        m_move = transform.TransformDirection(m_move);


        //// ジャンプ/重力処理
        m_move.y += y;
        if (m_characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.End))
            {
                m_move.y = m_jumpPower;
            }
        }
        m_move.y -= GRAVITY * Time.deltaTime;//重力を代入

        m_characterController.Move(m_move * Time.deltaTime);
        m_animator.SetFloat("Speed", m_characterController.velocity.magnitude);

    }

    private void Direction()
    {
        //左右方向転換
        Vector3 m_playerDirection = new Vector3(Input.GetAxisRaw("Mouse X2") * 10, 0.0f, 0.0f);
        m_playerDirection = transform.TransformDirection(m_playerDirection);
        if (m_playerDirection.magnitude > 0.1f)
        {
            Quaternion m_quaternion = Quaternion.LookRotation(m_playerDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_quaternion, m_rotationSpead * Time.deltaTime);
        }

        //上下への視点移動
        float xRotate = Input.GetAxis("Mouse Y2");
        if (cameraRotForward)
        {
            xRotate *= -1;
        }
        Quaternion cameraRotate = m_camera.rotation * Quaternion.Euler(xRotate * m_rotationSpead * Time.deltaTime, 0, 0);
        
        //カメラの角度が限界角度を超えてなければカメラの角度を更新する
        if (cameraRotateLimit > Quaternion.Angle(initCameraRot, Quaternion.Euler(cameraRotate.eulerAngles.x, 0, 0)))
        {
            m_camera.rotation = cameraRotate;
        }

    }
}
