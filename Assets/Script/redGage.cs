﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class redGage : MonoBehaviour
{

    [SerializeField]
    private GameObject[] b;

    [SerializeField]
    private GameObject p;

    [SerializeField]
    private GameObject max_Effect;
    private GameObject objEffect;



    private float t;
    private float maxValue;
    private RectTransform rt1;
    private RectTransform rt2;
    private RectTransform rt3;
    private RectTransform rt4;
    private RectTransform rt5;

    float[] c_time = { 1f, 1f, 1f, 1f, 1f, 1f };


    int setCount = 0;

    private int r_Bullet = 5;
    int r_number = 5;

    private bool E_Chenge = true;


    Bullet2 _B;
    private PlayerMove2 _pm;

    void Start()
    {
        _B = p.GetComponent<Bullet2>();
        _pm = p.GetComponent<PlayerMove2>();
        objEffect = max_Effect;
        objEffect.transform.GetComponent<Image>().color = new Color(1, 1, 1, 1);
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

        //maxValue = rt5.sizeDelta.x;
        maxValue = rt5.sizeDelta.y;

    }

    private void UpdateValue(float t)
    {
        //float y5 = Mathf.Lerp(maxValue, 0f, t);
        //float y4 = Mathf.Lerp(maxValue, 0f, t);
        //float y3 = Mathf.Lerp(maxValue, 0f, t);
        //float y2 = Mathf.Lerp(maxValue, 0f, t);
        //float y1 = Mathf.Lerp(maxValue, 0f, t);
        float y5 = Mathf.Lerp(0f, maxValue, t);
        float y4 = Mathf.Lerp(0f, maxValue, t);
        float y3 = Mathf.Lerp(0f, maxValue, t);
        float y2 = Mathf.Lerp(0f, maxValue, t);
        float y1 = Mathf.Lerp(0f, maxValue, t);



        //rt.sizeDelta = new Vector2(rt.sizeDelta.x, y);
        if (r_Bullet == 4)
        {
            //rt5.sizeDelta = new Vector2(rt5.sizeDelta.x, y5);
            rt5.sizeDelta = new Vector2(y5, rt5.sizeDelta.y);
        }
        else if (r_Bullet == 3)
        {
            //rt4.sizeDelta = new Vector2(rt4.sizeDelta.x, y4);
            rt4.sizeDelta = new Vector2(y4, rt4.sizeDelta.y);
        }
        else if (r_Bullet == 2)
        {
            //rt3.sizeDelta = new Vector2(rt3.sizeDelta.x, y3);
            rt3.sizeDelta = new Vector2(y3, rt3.sizeDelta.y);
        }
        else if (r_Bullet == 1)
        {
            //rt2.sizeDelta = new Vector2(rt2.sizeDelta.x, y2);
            rt2.sizeDelta = new Vector2(y2, rt2.sizeDelta.y);
        }
        else if (r_Bullet == 0)
        {
            //rt1.sizeDelta = new Vector2(rt1.sizeDelta.x, y1);
            rt1.sizeDelta = new Vector2(y1, rt1.sizeDelta.y);
        }

    }
    void bullet_UI()
    {
        r_number = r_Bullet;
        _B.Shot(r_Bullet);

        if (r_Bullet == 5)
        {
            //c_time[5] = 1f;
            //rt5.sizeDelta = new Vector2(rt5.sizeDelta.x, 0);
            c_time[5] = 0f;
            rt5.sizeDelta = new Vector2(1, rt5.sizeDelta.y);
        }
        else if (r_Bullet == 4)
        {
            //c_time[r_Bullet] = c_time[r_Bullet + 1];
            //c_time[r_Bullet + 1] = 1f;
            //rt5.sizeDelta = new Vector2(rt5.sizeDelta.x, 0);
            c_time[r_Bullet] = c_time[r_Bullet + 1];
            c_time[r_Bullet + 1] = 0f;
            rt5.sizeDelta = new Vector2(1, rt5.sizeDelta.y);
        }
        else if (r_Bullet == 3)
        {
            //c_time[r_Bullet] = c_time[r_Bullet + 1];
            //c_time[r_Bullet + 1] = 1f;
            //rt4.sizeDelta = new Vector2(rt4.sizeDelta.x, 0);
            c_time[r_Bullet] = c_time[r_Bullet + 1];
            c_time[r_Bullet + 1] = 0f;
            rt4.sizeDelta = new Vector2(1, rt4.sizeDelta.y);
        }
        else if (r_Bullet == 2)
        {
            //c_time[r_Bullet] = c_time[r_Bullet + 1];
            //c_time[r_Bullet + 1] = 1f;
            //rt3.sizeDelta = new Vector2(rt3.sizeDelta.x, 0);
            c_time[r_Bullet] = c_time[r_Bullet + 1];
            c_time[r_Bullet + 1] = 0f;
            rt3.sizeDelta = new Vector2(1, rt3.sizeDelta.y);
        }
        else if (r_Bullet == 1)
        {
            //c_time[r_Bullet] = c_time[r_Bullet + 1];
            //c_time[r_Bullet + 1] = 1f;
            //rt2.sizeDelta = new Vector2(rt2.sizeDelta.x, 0);
            c_time[r_Bullet] = c_time[r_Bullet + 1];
            c_time[r_Bullet + 1] = 0f;
            rt2.sizeDelta = new Vector2(1, rt2.sizeDelta.y);
        }
        r_Bullet--;

    }

    void Update()
    {
        if (setCount == 0)
            s_Shot();


        //if (c_time[r_number] >= 0f && r_Bullet <= 5)
        //    c_time[r_number] -= Time.deltaTime * 0.5f;


        if (c_time[r_number] <= 1f && r_Bullet <= 5)
            c_time[r_number] += Time.deltaTime * 0.5f;

        UpdateValue(c_time[r_number]);


        //if (c_time[r_number] <= 0f && r_Bullet < 5)
        //{

        //    r_Bullet++;
        //    if (r_number == 5) return;
        //    r_number++;
        //}
        if (c_time[r_number] >= 1f && r_Bullet < 5)
        {
            r_Bullet++;
            if (r_number != 5) r_number++;
        }

        if (r_Bullet == 5)
        {
            EffectON();
            EffectFlash();
            //StartCoroutine(EffectFlash());
        }
        else
        {
            EffectOFF();
        }


        if (!_pm.DESCHECK2)
        {

            if (Input.GetButtonDown("Fire1_2") && r_Bullet > 0)
            {
                bullet_UI();

            }
        }

    }
    void EffectFlash()
    {

        if (objEffect.transform.GetComponent<Image>().color.a <= 150 / 255)
        {
            E_Chenge = true;
        }
        else if (objEffect.transform.GetComponent<Image>().color.a >= 255 / 255)
        {
            E_Chenge = false;
        }

        if (E_Chenge)
        {
            objEffect.transform.GetComponent<Image>().color += new Color(0, 0, 0, Time.deltaTime / 2);
        }
        else
        {
            objEffect.transform.GetComponent<Image>().color -= new Color(0, 0, 0, Time.deltaTime / 2);
        }
    }
    void EffectON()
    {
        if (objEffect.activeInHierarchy == true) return;
        objEffect.transform.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        objEffect.SetActive(true);
    }
    void EffectOFF()
    {
        if (objEffect.activeInHierarchy == false) return;
        objEffect.SetActive(false);
    }


}
