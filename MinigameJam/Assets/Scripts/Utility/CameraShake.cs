using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{
    private CinemachineImpulseSource shake = null;

    private void Start ()
    {
        shake = GetComponent<CinemachineImpulseSource> ();
    }
    public void Shake ()
    {
        shake.GenerateImpulse ();
    }
}
