using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class blueGage : MonoBehaviour
{

    [SerializeField]
    private GameObject[] b;

    [SerializeField]
    private GameObject p;


    private float t;
    private float maxValue;
    private RectTransform rt1;
    private RectTransform rt2;
    private RectTransform rt3;
    private RectTransform rt4;
    private RectTransform rt5;

    float[] c_time = { 0f, 0f, 0f, 0f, 0f, 0f };


    int setCount = 0;

    private int b_Bullet = 5;
    int b_number=5;

    Bullet _B;

    void Start()
    {
        _B = p.GetComponent<Bullet>();
    }

    void s_Shot()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == 0)
            {
                rt1 = b[i].transform.FindChild("Gage").gameObject.GetComponent<RectTransform>();
            }
            else if (i == 1)
            {
                rt2 = b[i].transform.FindChild("Gage").gameObject.GetComponent<RectTransform>();
            }
            else if (i == 2)
            {
                rt3 = b[i].transform.FindChild("Gage").gameObject.GetComponent<RectTransform>();
            }
            else if (i == 3)
            {
                rt4 = b[i].transform.FindChild("Gage").gameObject.GetComponent<RectTransform>();
            }
            else if (i == 4)
            {
                rt5 = b[i].transform.FindChild("Gage").gameObject.GetComponent<RectTransform>();
            }
            else
            {
                break;
            }

        }
        setCount++;

        maxValue = rt5.sizeDelta.x;
    }


    private void UpdateValue(float t)
    {
        float y5 = Mathf.Lerp(maxValue, 0f, t);
        float y4 = Mathf.Lerp(maxValue, 0f, t);
        float y3 = Mathf.Lerp(maxValue, 0f, t);
        float y2 = Mathf.Lerp(maxValue, 0f, t);
        float y1 = Mathf.Lerp(maxValue, 0f, t);



        //rt.sizeDelta = new Vector2(rt.sizeDelta.x, y);
        if (b_Bullet == 4)
        {
            rt5.sizeDelta = new Vector2(rt5.sizeDelta.x, y5);
        }
        else if (b_Bullet == 3)
        {
            rt4.sizeDelta = new Vector2(rt4.sizeDelta.x, y4);
        }
        else if (b_Bullet == 2)
        {
            rt3.sizeDelta = new Vector2(rt3.sizeDelta.x, y3);
        }
        else if (b_Bullet == 1)
        {
            rt2.sizeDelta = new Vector2(rt2.sizeDelta.x, y2);
        }
        else if (b_Bullet == 0)
        {
            rt1.sizeDelta = new Vector2(rt1.sizeDelta.x, y1);
        }

    }
    void bullet_UI()
    {
        b_number = b_Bullet;


        _B.Shot(b_Bullet);

        if (b_Bullet == 5)
        {
            c_time[5] = 1f;
            rt5.sizeDelta = new Vector2(rt5.sizeDelta.x, 0);
        }
        else if (b_Bullet == 4)
        {
            c_time[b_Bullet] = c_time[b_Bullet + 1];
            c_time[b_Bullet + 1] = 1f;
            rt5.sizeDelta = new Vector2(rt5.sizeDelta.x, 0);
        }
        else if (b_Bullet == 3)
        {
            c_time[b_Bullet] = c_time[b_Bullet + 1];
            c_time[b_Bullet + 1] = 1f;
            rt4.sizeDelta = new Vector2(rt4.sizeDelta.x, 0);
        }
        else if (b_Bullet == 2)
        {
            c_time[b_Bullet] = c_time[b_Bullet + 1];
            c_time[b_Bullet + 1] = 1f;
            rt3.sizeDelta = new Vector2(rt3.sizeDelta.x, 0);
        }
        else if (b_Bullet == 1)
        {
            c_time[b_Bullet] = c_time[b_Bullet + 1];
            c_time[b_Bullet + 1] = 1f;
            rt2.sizeDelta = new Vector2(rt2.sizeDelta.x, 0);
        }
        b_Bullet--;
    }

    void Update()
    {
        if (setCount == 0)
            s_Shot();

        
        if (c_time[b_number] >= 0f && b_Bullet <= 5)
            c_time[b_number] -= Time.deltaTime * 0.5f;

        UpdateValue(c_time[b_number]);


        if (c_time[b_number] <= 0f && b_Bullet < 5)
        {

            b_Bullet++;
            if (b_number == 5) return;
            b_number++;
        }

        if (Input.GetButtonDown("Fire1_1") && b_Bullet > 0)
        {
            bullet_UI();

        }


    }


}
