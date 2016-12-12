using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    readonly float PLAYER_SPEED = 1.0f;

    CharacterController characterController;
    Animator animator;

    private Vector3 postion;
    private float m_rotationSpead = 360.0f;
    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        postion = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal1");
        float vertical = Input.GetAxis("Vertical1");
       
        Vector3 input = new Vector3(horizontal, 0, vertical);

        postion = input;

        postion = transform.TransformDirection(postion);
        characterController.Move(postion*Time.deltaTime);
        animator.SetFloat("Speed", characterController.velocity.magnitude);

    }

    public void Direction()
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
