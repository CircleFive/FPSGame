using UnityEngine;
using System.Collections;

/*


    主にPlayerの移動と方向転換をするためのScript


*/

public class PlayerMove : MonoBehaviour {

    public float m_moveSpead;
    public float m_jumpPower;
    private float m_rotationSpead=180.0f;

    private Vector3 m_move = Vector3.zero;
    
    private float m_speed = 5.0f;

    private const float GRAVITY = 9.8f;

    CharacterController m_characterController;
    Animator m_animator;

    [SerializeField]
    private float cameraRotateLimit;
    [SerializeField]
    private bool cameraRotForward;                     //マウスを上で上を向く場合はtrue,マウスを上で下を向く場合はfalse

    private Quaternion initCameraRot;

    private Transform m_camera;
    
    
    [SerializeField]
    private Transform m_spine;                        //プレイヤーの背のボーン指定

    public enum PlayerStatus
    {
        Idle = 0,
        Run_F,
        Run_B,
        Run_L,
        Run_R,
        Run_FL,
        Run_FR,
        Run_BL,
        Run_BR,
        STAND_GUN,
        Run_GUN
    };

    private PlayerStatus status = PlayerStatus.Idle;
   
    [SerializeField]
    private ChangeAnimation changeAnimation = null;
    public PlayerStatus GetStatus { get { return status; } }
    // Use this for initialization
    void Start () {
       
        m_camera = GetComponentInChildren<Camera>().transform;
        m_characterController = GetComponent<CharacterController>();
        m_animator = GetComponentInChildren<Animator>();
        initCameraRot = m_camera.rotation;
       
       // changeAnimation = GetComponent<ChangeAnimation>();
        status = PlayerStatus.Idle;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Direction();
        //Animation();
    }


    private void Move()
    {
        //移動処理
        float y = m_move.y;
        m_move = new Vector3(Input.GetAxis("Horizontal1"), 0, Input.GetAxis("Vertical1"));
        
        
        m_move = transform.TransformDirection(m_move);


        //// ジャンプ/重力処理
        m_move.y += y;
        if (m_characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                m_move.y = m_jumpPower;
            }
        }
        m_move.y -= GRAVITY * Time.deltaTime;//重力を代入

        m_characterController.Move(m_move*Time.deltaTime*m_speed);
       m_animator.SetFloat("Speed", m_characterController.velocity.magnitude);

    }


    //public void Animation()
    //{

    //}


    private void Direction()
    {
        //左右方向転換
        Vector3 m_playerDirection = new Vector3(Input.GetAxis("Mouse X1") * 10, 0.0f, 0.0f);
        m_playerDirection = transform.TransformDirection(m_playerDirection);
        if (m_playerDirection.magnitude > 0.1f)
        {
            Quaternion m_quaternion = Quaternion.LookRotation(m_playerDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_quaternion, m_rotationSpead * Time.deltaTime);
        }

        //上下への視点移動
        float xRotate = Input.GetAxis("Mouse Y1");
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

    //Playerモデルの上半身の角度を変える
    void LateUpdate()
    {
        m_spine.eulerAngles = new Vector3(m_camera.eulerAngles.x, m_camera.eulerAngles.y, 0);
    }

}