using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetNumber : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Start ()
    {
        text = GetComponent<TextMeshProUGUI> ();
    }
    private void Update ()
    {
        text.text = IsFinished.number.ToString();
    }
}
