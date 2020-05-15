using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private Material mat;

    void Start()
    {
        mat = gameObject.GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        Color newColor = mat.color;
        newColor.a -= Time.deltaTime * 0.2f;
        mat.color = newColor;
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }
}
