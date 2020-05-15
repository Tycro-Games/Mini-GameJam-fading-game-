using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnShoot = null;

    private void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        StartCoroutine (Shooting ());
    }

    IEnumerator Shooting ()
    {
        OnShoot.Invoke ();
        yield return null;
    }
}
