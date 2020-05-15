using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPos : MonoBehaviour
{
    [SerializeField]
    private Transform ToFollow=null;

    private void Update ()
    {
   
        transform.position = ToFollow.position;
    }
}
