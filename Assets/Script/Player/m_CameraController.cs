using UnityEngine;
using System.Collections;

public class m_CameraController : MonoBehaviour
{

    [SerializeField]
    private float x_aspect;
    [SerializeField]
    private float y_aspect;

    void Awake()
    {
        Rect rect;
        Camera camera = GetComponent<Camera>();
        if(gameObject.name == "m_Camera1")
        {
            rect = calcAspect1(x_aspect, y_aspect);

        }else
        {
            rect = calcAspect2(x_aspect, y_aspect);

        }
        camera.rect = rect;
    }

    private Rect calcAspect1(float width, float height)
    {
        float target_aspect = width / height;
        float window_aspect = (float)Screen.width / (float)Screen.height;
        float scale_height = window_aspect / target_aspect;
        Rect rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        if (1.0f > scale_height)
        {
            rect.x = 0;
            rect.y = 0.525f;
            rect.width = 1.0f;
            rect.height = scale_height;
        }
        else
        {
            float scale_width = 1.0f / scale_height;
            rect.x = (1.0f - scale_width) / 2.0f;
            rect.y = 0.53f;
            rect.width = scale_width;
            rect.height = 1.0f;
        }
        return rect;
    }
    private Rect calcAspect2(float width, float height)
    {
        float target_aspect = width / height;
        float window_aspect = (float)Screen.width / (float)Screen.height;
        float scale_height = (window_aspect / target_aspect) - 0.525f;
        Rect rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        if (1.0f > scale_height)
        {
            rect.x = 0;
            rect.y = 0.025f;
            rect.width = 1.0f;
            rect.height = scale_height;
        }
        else
        {
            float scale_width = 1.0f / scale_height;
            rect.x = (1.0f - scale_width) / 2.0f;
            rect.y = 0.53f;
            rect.width = scale_width;
            rect.height = 1.0f;
        }
        return rect;
    }


}