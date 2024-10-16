using EZCameraShake;
using UnityEngine;

public class EzCameraShakeConstant : MonoBehaviour
{
    [Header("Screenshake Values")]
    [SerializeField] private float ss_Magnitude, ss_Roughness, ss_FadeInTime, ss_FadeOutTime;
    [Header("Screenshake Rotation and Position Influence")]
    [SerializeField] private Vector3 ss_PositionInfluence, ss_RotationInfluence;

    private void Start()
    {
        DoScreenshakeNoInfluence();
    }
    public void DoScreenshakeNoInfluence()
    {
        CameraShaker.Instance.ShakeOnce(ss_Magnitude, ss_Roughness, ss_FadeInTime, ss_FadeOutTime);
    }
    public void DoScreenshakeYesInfluence()
    {
        CameraShaker.Instance.ShakeOnce(ss_Magnitude, ss_Roughness, ss_FadeInTime, ss_FadeOutTime, ss_PositionInfluence, ss_RotationInfluence);
    }
}