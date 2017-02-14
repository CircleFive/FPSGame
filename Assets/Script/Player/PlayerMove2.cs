using UnityEngine;
using System.Collections;

public class PlayerMove2 : MonoBehaviour
{

    private float m_moveSpead = 5.0f;
    private float m_jumpPower = 1.5f;
   
    private Vector3 m_move = Vector3.zero;

    private float m_speed = 5.0f;

    private const float GRAVITY = 4.0f;
    private bool j_flg = true;
    private Rigidbody j_posDown;
    private bool jAnimbool = false;


    private AnimatorStateInfo animState;
    private readonly float waitTime = 0.1f;
    private readonly float landingDistance = 0.5f;
    private readonly int landingCheckLimit = 100;

    CharacterController m_characterController;
    private Animator m_animator;

    public Animator M_ANIMATOR
    {
        get { return m_animator; }
        set { m_animator = value; }
    }

    private float x;
    private float y;
    private float z;

    private bool setanim = false;
    private string animName = "None";

    private bool descheck2 = false;

    public bool DESCHECK2
    {
        get { return descheck2; }
        set { descheck2 = value; }
    }

    private int _statedeath, _stateJumpCard;
    AnimatorStateInfo thisAnim;

    private float risTime = 0.0f;
    private bool risbool = false;
    public bool RISBOOL
    {
        get { return risbool; }
        set { risbool = value; }
    }

    // true : 立ち ,  false : しゃがみ
    private bool stateBool = true;

    private bool noHit = false;
    public bool NOHIT
    {
        get { return noHit; }
        set { noHit = value; }
    }

    private bool crouchTop;
    public bool CROUCHTOP
    {
        get { return crouchTop; }
        set { crouchTop = value; }

    }

    private bool _NoContllol = false;


    [SerializeField]
    private Transform m_playerRay;  // レイを飛ばす体の位置
    private float m_playerRayRange = 1.15f; //　レイの距離

    // Use this for initialization
    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        this.m_animator = GetComponentInChildren<Animator>();
        j_posDown = this.gameObject.GetComponent<Rigidbody>();
        animState = m_animator.GetCurrentAnimatorStateInfo(0);
        this._statedeath = Animator.StringToHash("Base Layer.death");
        RISBOOL = risbool;
    }

    private IEnumerator risWait()
    {
        yield return new WaitForSeconds(0.1f);
        m_characterController.enabled = true;
        M_ANIMATOR.SetBool("death", DESCHECK2);
        M_ANIMATOR.SetBool("Idel", true);
        yield return new WaitForSeconds(3.0f);
        NOHIT = false;
    }

    private IEnumerator NoContllol()
    {
        yield return new WaitForSeconds(0.1f);
        _NoContllol = false;
    }

    // Update is called once per frame
    void Update()
    {
        thisAnim = this.m_animator.GetCurrentAnimatorStateInfo(0);
        if (DESCHECK2)
        {
            risTime += Time.deltaTime;

            m_characterController.enabled = false;

            m_animator.SetBool(animName, false);
            M_ANIMATOR.SetBool("death", DESCHECK2);

            //if (m_animator.GetCurrentAnimatorStateInfo(1644927660).normalizedTime >= 0.9f)
            if (risTime >= 5.5f)
            {
                risTime = 0.0f;

                //risbool = true;
                RISBOOL = true;
                DESCHECK2 = false;
                _NoContllol = true;
                StartCoroutine(NoContllol());
                StartCoroutine(risWait());
            }
        }
        if (!DESCHECK2)
        {
            if (Input.GetButton("R2button_2"))
            {
                CrouchState();
                m_animator.SetBool("State", false);
            }
            else
            {
                if (crouchTop == false)
                {
                    StandState();
                    m_animator.SetBool("State", true);
                }
            }
            Move();
        }
    }

    private void CrouchState()
    {
        if (stateBool == false) return;
        m_characterController.center = new Vector3(0, 0.65f, 0);
        m_characterController.height = 1.2f;
        stateBool = false;
    }
    private void StandState()
    {
        if (stateBool == true) return;
        m_characterController.center = new Vector3(0, 1.0f, 0);
        m_characterController.height = 2.0f;
        stateBool = true;
    }


    private void StandAnim()
    {
        if (x >= 0.1f && x <= -0.1f && z >= 0.1f && z <= -0.1f)
        {
            setanim = false;
        }
        else
        {
            m_animator.SetBool("Idle", false);
            setanim = true;
        }

        if (x > 0.1f && z > 0.1f) // 右上 
        {
            m_animator.SetBool(animName, false);
            animName = "UR";
            m_animator.SetBool("UR", setanim);
        }
        else if (x < -0.1f && z > 0.1f) // 左上
        {
            m_animator.SetBool(animName, false);
            animName = "UL";
            m_animator.SetBool("UL", setanim);
        }
        else if (x > 0.1f && z < -0.1f) // 右下
        {
            m_animator.SetBool(animName, false);
            animName = "DR";
            m_animator.SetBool("DR", setanim);
        }
        else if (x < -0.1f && z < -0.1f) // 左下
        {
            m_animator.SetBool(animName, false);
            animName = "DL";
            m_animator.SetBool("DL", setanim);
        }
        else if (x > 0.1f) //　右 
        {
            m_animator.SetBool(animName, false);
            animName = "R";
            m_animator.SetBool("R", setanim);
        }
        else if (x < -0.1f) // 左
        {
            m_animator.SetBool(animName, false);
            animName = "L";
            m_animator.SetBool("L", setanim);
        }
        else if (z > 0.1f) // 上
        {
            m_animator.SetBool(animName, false);
            animName = "U";
            m_animator.SetBool("U", setanim);
        }
        else if (z < -0.1f) // 下
        {
            m_animator.SetBool(animName, false);
            animName = "D";
            m_animator.SetBool("D", setanim);
        }
        else
        {
            m_animator.SetBool(animName, setanim);
            //animName = "Idle";
            m_animator.SetBool("Idle", true);
        }


    }

    IEnumerator CheckLanding()
    {

        // 規定回数チェックして成功しない場合も着地モーションに移行する
        for (int count = 0; count < landingCheckLimit; count++)
        {
            var raycast = new RaycastHit();
            var raycastSuccess = Physics.Raycast(transform.position, Vector3.down, out raycast);
            // レイを飛ばして、成功且つ一定距離内であった場合、着地モーションへ移項させる
            if (raycastSuccess && raycast.distance < landingDistance) break;
            yield return new WaitForSeconds(waitTime);
            m_animator.SetBool("jumpDown", true);
            m_animator.SetBool("jumpUp", false);
        }
    }

    private void Move()
    {
        //移動処理
        y = m_move.y;
        if (!_NoContllol)
        {
            m_move = new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2"));
            // m_move = new Vector3(Input.GetAxis("Horizontal1_1"), 0, Input.GetAxis("Vertical1_1"));
            x = m_move.x;
            z = m_move.z;

            m_move.y += y;

            m_move = transform.TransformDirection(m_move);
        }
        RaycastHit hit;
        bool spherHit = Physics.SphereCast(m_playerRay.position + Vector3.up * 0.13f, 0.1f, -Vector3.up, out hit, m_playerRayRange);

        //ジャンプ / 重力処理
        if (spherHit == true)
        {
            if (jAnimbool)
            {
                //m_animator.SetBool("jumpDown", true);
                jAnimbool = false;
            }

            m_animator.SetBool("jumpDown", false);

            //if (animState.nameHash == Animator.StringToHash("Base Layer.jumpDown"))
            //    m_animator.SetTrigger("jumpDown1");
            if (m_move.y != 0)
                m_move.y = 0f;
            if (Input.GetButtonDown("button3_2"))
            {
                //m_animator.SetTrigger("jumpUp1");
                m_animator.SetBool(animName, false);
                jAnimbool = true;
                m_animator.SetBool("jumpUp", true);
                m_move.y = m_jumpPower;
            }
        }
        else if (spherHit == false)
        {
            m_move.y -= GRAVITY * Time.deltaTime;//重力を代入
            //if (animState.nameHash == Animator.StringToHash("Base Layer.jump.jumpUp"))
            StartCoroutine(CheckLanding());
        }

        if (!jAnimbool)
            StandAnim();

        // 立ち状態の場合
        if (stateBool == true)
            m_characterController.Move(m_move * (Time.deltaTime * m_speed));
        // しゃがみ状態の場合
        else
            m_characterController.Move((m_move * (Time.deltaTime * m_speed)) / 1.8f);
       
    }

}
