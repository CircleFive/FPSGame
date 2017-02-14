using UnityEngine;
using System.Collections;

public class m_CameraController : MonoBehaviour
{

    [SerializeField]
    private float x_aspect;
    [SerializeField]
    private float y_aspect;


    private Rect maxport;

    void Awake()
    {
        Rect rect;
        Camera camera = GetComponent<Camera>();
        if(gameObject.name == "m_Camera1")
        {
            rect = calcAspect1(x_aspect, y_aspect);
        }
        else
        {
            rect = calcAspect2(x_aspect, y_aspect);

        }
        //camera.rect = rect;
        maxport = rect;

    }

    public Rect getChegeRect()
    {
        return maxport;
    }

    private Rect calcAspect1(float width, float height)
    {
        float target_aspect = width / height;
        float window_aspect = (float)Screen.width / (float)Screen.height;
        float scale_height = window_aspect / target_aspect;
        Rect rect1 = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        if (1.0f > scale_height)
        {
            rect1.x = 0;
            rect1.y = 0.525f;
            rect1.width = 1.0f;
            rect1.height = scale_height;
        }
        else
        {
            float scale_width = 1.0f / scale_height;
            rect1.x = (1.0f - scale_width) / 2.0f;
            rect1.y = 0.53f;
            rect1.width = scale_width;
            rect1.height = 1.0f;
        }
        return rect1;
    }
    private Rect calcAspect2(float width, float height)
    {
        float target_aspect = width / height;
        float window_aspect = (float)Screen.width / (float)Screen.height;
        float scale_height = (window_aspect / target_aspect) - 0.525f;
        Rect rect2 = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        if (1.0f > scale_height)
        {
            rect2.x = 0;
            rect2.y = 0.025f;
            rect2.width = 1.0f;
            rect2.height = scale_height;
        }
        else
        {
            float scale_width = 1.0f / scale_height;
            rect2.x = (1.0f - scale_width) / 2.0f;
            rect2.y = 0.53f;
            rect2.width = scale_width;
            rect2.height = 1.0f;
        }
        return rect2;
    }


}