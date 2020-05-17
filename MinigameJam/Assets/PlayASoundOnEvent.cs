using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlayASoundOnEvent : MonoBehaviour
{
    private AudioSource source=null;
    private void Start ()
    {
        source = GetComponent<AudioSource> ();
    }
    public void PlaySound ()
    {
        source.Play ();
    }
}
