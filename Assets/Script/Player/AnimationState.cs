using UnityEngine;
using System.Collections;

public class AnimationState : MonoBehaviour{

    public enum AnimeType
    {
        Idle = 0,
        Run_F,
        Run_B,
        Run_L,
        Run_R,
        Run_FL,
        Run_FR,
        Run_BL,
        Run_BR,
        Stand_Gun,
        Run_Gun,
        Break
    };

    
    private Animator animator=null;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Play(AnimeType type)
    {
        Debug.Log(type);
        animator.Play(type.ToString());
        
    }

}
