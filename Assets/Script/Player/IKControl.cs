using UnityEngine;
using System.Collections;

public class IKControl : MonoBehaviour {

    private Animator m_ikControl;

    [SerializeField]
    private Transform m_rightHand;           //PlayerModelの右手
    [SerializeField]
    private Transform m_rightForeArm;        //PlayerModelの右ひじ

    [SerializeField]
    private Transform m_leftHand;            //PlayerModelの左手
    [SerializeField]
    private Transform m_leftForeArm;        //PlayerModelの左ひじ

    [SerializeField]
    private Transform m_lookObj;

    // Use this for initialization
    void Start () {

        m_ikControl = GetComponent<Animator>();

	}

    private void OnAnimatorIK(int layerIndex)
    {
        //右手
        m_ikControl.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        m_ikControl.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        m_ikControl.SetIKPosition(AvatarIKGoal.RightHand, m_rightHand.position);
        m_ikControl.SetIKRotation(AvatarIKGoal.RightHand, m_rightHand.rotation);
        //右ひじ
        m_ikControl.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1);
        m_ikControl.SetIKHintPosition(AvatarIKHint.RightElbow, m_rightForeArm.position);
        //左手
        m_ikControl.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        m_ikControl.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        m_ikControl.SetIKPosition(AvatarIKGoal.LeftHand, m_leftHand.position);
        m_ikControl.SetIKRotation(AvatarIKGoal.LeftHand, m_leftHand.rotation);
        //左ひじ
        m_ikControl.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1);
        m_ikControl.SetIKHintPosition(AvatarIKHint.LeftElbow, m_leftForeArm.position);

        m_ikControl.SetLookAtWeight(1);
        m_ikControl.SetLookAtPosition(m_lookObj.position);
        //    if (m_ikControl)
        //    {
        //        if (m_ikActive)
        //        {
        //            if (m_lookObj != null)
        //            {
        //                m_ikControl.SetLookAtWeight(1);
        //                m_ikControl.SetLookAtPosition(m_lookObj.position);
        //            }

        //            if (m_rightHand != null && m_leftHand != null)
        //            {
        //                m_ikControl.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        //                m_ikControl.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        //                m_ikControl.SetIKPosition(AvatarIKGoal.RightHand, m_rightHand.position);
        //                m_ikControl.SetIKRotation(AvatarIKGoal.RightHand, m_rightHand.rotation);

        //                m_ikControl.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        //                m_ikControl.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        //                m_ikControl.SetIKPosition(AvatarIKGoal.LeftHand, m_leftHand.position);
        //                m_ikControl.SetIKRotation(AvatarIKGoal.RightHand, m_leftHand.rotation);

        //            }

        //        }
        //        else
        //        {
        //            m_ikControl.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
        //            m_ikControl.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
        //            m_ikControl.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
        //            m_ikControl.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);

        //            m_ikControl.SetLookAtWeight(0);
        //        }
        //    }
    }


}
