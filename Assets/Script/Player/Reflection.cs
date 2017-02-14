using UnityEngine;
using System.Collections;

public class Reflection : MonoBehaviour {

   
    LineRenderer m_laser;
    [SerializeField]
    private Transform m_setPosition;
    [SerializeField]
    private Transform m_laserPosition;
    [SerializeField]
    private Transform m_wall;

    private RaycastHit m_hit;

	// Use this for initialization
	void Start () {
        m_laser = GetComponent<LineRenderer>();
        m_laser.SetPosition(1, m_setPosition.transform.forward * 10*-1);
	}
	
	// Update is called once per frame
	void Update () {
        // m_laser.SetPosition(1, Vector3.Reflect(m_wall.position,Vector3.right));

        if (Physics.Raycast(m_laserPosition.transform.position, m_setPosition.transform.forward, out m_hit))
        {
            m_laser.SetPosition(1, m_hit.point);
        }
        else
        {
            m_laser.SetPosition(1, m_setPosition.transform.forward * 10 * -1);
        }

    }
}
