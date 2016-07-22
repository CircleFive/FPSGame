using UnityEngine;
using System.Collections;

public class ReflectVector : MonoBehaviour {

    //Vector3 vec1,vec2,vi,nDush,vf;
    //public GameObject m_gameObject;
    //public GameObject m_vectorObject;

        public GameObject m_gameObject;

  void Start () {
        //  //平面ベクトル
        // vec1 = new Vector3(m_vectorObject.transform.position.x, m_vectorObject.transform.position.y, m_vectorObject.transform.position.z);
        // vec2 = new Vector3(m_vectorObject.transform.position.x, m_vectorObject.transform.position.y, m_vectorObject.transform.position.z);

        //vi= new Vector3(m_gameObject.transform.position.x, m_gameObject.transform.position.y, m_gameObject.transform.position.z);//進入ベクトル

        //nDush = Vector3.Cross(vec1,vec2).normalized;  //外積により法線を得る（正規化）
        // vf = Vector3.Reflect(-vi,nDush);

        MeshFilter mf = m_gameObject.GetComponent<MeshFilter>();
        Vector3[] nor = mf.mesh.normals;

   }
   
   void Update () {
        //Debug.DrawLine(Vector3.zero,vec1);
        //Debug.DrawLine(Vector3.zero,vec2);
        //Debug.DrawLine(Vector3.zero,nDush,Color.blue);
        //Debug.DrawLine(Vector3.zero,vi,Color.green);
        //Debug.DrawLine(Vector3.zero,vf,Color.red);
   }

    void FixedUpdate()
    {

    }
}
