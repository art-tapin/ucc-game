using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
    public Animator animator;
    public CinemachineStateDrivenCamera camera;

    public void ZoomSceneTrue()
    {
        camera.m_DefaultBlend.m_Time = 0.0f;
        animator.SetBool("zoomOutScene", true);
    }
    
    public void ZoomSceneFalse()
    {
        camera.m_DefaultBlend.m_Time = 3.0f;
        animator.SetBool("zoomOutScene", false);
    }
}