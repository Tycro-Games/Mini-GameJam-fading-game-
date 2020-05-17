using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject Effect;

    public void SpawningEffect ()
    {
       GameObject ob= Instantiate (Effect, transform.position, transform.rotation);
        Destroy (ob, 3);
    }
}
