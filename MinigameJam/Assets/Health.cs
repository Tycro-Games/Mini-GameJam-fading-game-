using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Material black;

    private void Start ()
    {
        black.SetFloat ("_Saturation", 1);
    }
    public void ChangeInHealth (float dif = 0.25f)
    {
        black.SetFloat ("_Saturation", black.GetFloat ("_Saturation") - dif);
        if (black.GetFloat ("_Saturation") <= 0)
            Debug.Log ("loose");
    }
    public void ADDInHealth (float dif = 0.05f)
    {
        if (black.GetFloat ("_Saturation") < 1)
            black.SetFloat ("_Saturation", black.GetFloat ("_Saturation") + dif);
    }
}
