using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkipPart : MonoBehaviour
{
    [SerializeField]
    private UnityEvent Unity;

    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            Unity.Invoke ();
            Destroy (this);
        }
    }
}
