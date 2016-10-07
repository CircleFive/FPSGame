using UnityEngine;
using System.Collections;

public class LaserParticle : MonoBehaviour {

    private ParticleSystem m_laser;
    public Transform m_muzzle;
   

	// Use this for initialization
	void Start () {

        m_laser = this.GetComponent<ParticleSystem>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        m_laser.transform.position = m_muzzle.position;
        m_laser.startSize = 0.2f;
        if (Input.GetButtonDown("Fire1"))
        {
            m_laser.Play();
        }
        m_laser.transform.rotation = Quaternion.Euler(0, 0, 0);
	}

    void OnParticleCollision(GameObject objct)
    {
        if (objct.gameObject.tag == "Wall")
        {
            Object.Destroy(gameObject);
        }
    }
}
