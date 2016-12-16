using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class stageCollapse : MonoBehaviour
{

    float time;
    Vector3 pos;
    private GameObject stage;

    int i;
    bool collapseHeraldFlg = true;

    [SerializeField]
    private List<Transform> child;


    void Start()
    {
        stage = (GameObject)Resources.Load("Cube");
        Invoke("addChild",1.5f);
    }

    void addChild()
    {
        foreach (Transform obj in transform)
        {
            if (obj != this.transform && obj.tag == "CubeCollapce")
                child.Add(obj.transform);
        }

    }

    void Update()
    {

        time += Time.deltaTime;
        foreach (Transform obj in child)
        {

            if(obj == null)
            {
                continue;
            }
            if (obj.tag == "CubeCollapce")
            {
                if (time > 120)
                {
                    pos = new Vector3(0, pos.y + 0.01f * Time.deltaTime, 0);
                    obj.transform.position -= pos;
                }

                if (time > 123) Destroy(obj.gameObject);
            }
        }
    }



}
