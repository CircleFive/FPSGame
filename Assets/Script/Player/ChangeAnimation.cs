using UnityEngine;
using System.Collections;

public class ChangeAnimation : MonoBehaviour {

    [SerializeField]
    private AnimationState animator=null;
    [SerializeField]
    private AnimationState.AnimeType status=AnimationState.AnimeType.Idle;

    public void ChangeRunForward()
    { 
        status = AnimationState.AnimeType.Run_F;
        animator.Play(status);
    }

    //public void ChangeRunBack()
    //{
    //    animator.Play("Run_B",0,0);
    //}

    //public void ChangeRunLeft()
    //{
    //    animator.Play("Run_L");
    //}

    //public void ChangeRunRight()
    //{
    //    animator.Play("Run_R");
    //}

    //public void ChangeRunFL()
    //{
    //    animator.Play("Run_F+L");
    //}

    //public void ChangeRunFR()
    //{
    //    animator.Play("Run_F+R");
    //}

    //public void ChangeRunBL()
    //{
    //    animator.Play("Run_B+L");
    //}

    //public void ChangeRunBR()
    //{
    //    animator.Play("Run_B+R");
    //}

    public void ChangeIdle()
    {
        status = AnimationState.AnimeType.Break;
        animator.Play(status);
    }

    //public void ChangeStandGun()
    //{
    //    animator.Play("Stand_Gun");
    //}

    //public void ChangeRunGun()
    //{
    //    animator.Play("Run_F_Gun");
    //}

}
