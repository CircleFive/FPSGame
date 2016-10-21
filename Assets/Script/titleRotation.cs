using UnityEngine;
using System.Collections;

public class titleRotation : MonoBehaviour
{


    [SerializeField]
    private GameObject r1;
    [SerializeField]
    private GameObject r2;

    float addRotation;

    Vector3 rr1;
    Vector3 rr2;

    void Start()
    {
        rr1 = new Vector3();
        rr2 = new Vector3();
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1_1"))
        {
            r1.transform.rotation = new Quaternion();

            addRotation = Random.Range(-60.0f, 50.0f);

            if (360 + addRotation > 360)
            {
                rr1 = new Vector3(rr1.x, addRotation, rr1.z);

            }
            else
            {
                rr1 = new Vector3(rr1.x, 360 + addRotation, rr1.z);
            }
            r1.transform.Rotate(new Vector3(0, addRotation, 0));
        }


        if (Input.GetButtonDown("Fire1_2"))
        {
            r2.transform.rotation = new Quaternion();

            addRotation = Random.Range(-60.0f, 50.0f);

            if (360 + addRotation > 360)
            {
                rr2 = new Vector3(rr2.x, addRotation, rr2.z);

            }
            else
            {
                rr2 = new Vector3(rr2.x, 360 + addRotation, rr2.z);
            }
            r2.transform.Rotate(new Vector3(0, addRotation, 0));
        }
    }
}