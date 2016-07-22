using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    //LineRendererオブジェクト設定
    public GameObject lineObject;

    public GameObject bullet;

    //射程
    private float range = 1.5f;

    private float width = 2.0f;

    private float speed = 2;

    public Transform muzzle;

    LineRenderer lineRenderer;

    RaycastHit hit;

	// Use this for initialization
	void Start () {

        GameObject line = Instantiate(lineObject, muzzle.position, Quaternion.identity) as GameObject;

        lineRenderer = line.GetComponent<LineRenderer>();

        //LineRenderer設定
        //始点と終点を結ぶ
        lineRenderer.SetVertexCount(2);

        lineRenderer.SetWidth(width, width);
        
	}
	
	// Update is called once per frame
	void Update () {

      
        if (Input.GetButtonDown("Fire1"))
        {
            SetLaser();
        }
       
	}


    void SetLaser()
    {


        //始点
        Vector3 start;
        //始点を設定
        start = muzzle.position;

        lineRenderer.SetPosition(0, start);

        //終点
        Vector3 end;
        //終点を設定する（終点は始点からmuzzuleの前方向にrange分伸ばした先に設定される）
        end = start + (muzzle.forward * range);

        //終点を設定する
        lineRenderer.SetPosition(1, end * Time.deltaTime);


        //GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
        //bullets.transform.position = muzzle.position;
        //Vector3 m_force;
        //m_force = lineRenderer.transform.forward * speed;
        //bullets.GetComponent<Rigidbody>().AddForce(m_force);
        //Destroy(bullets, 3);
    }


}
