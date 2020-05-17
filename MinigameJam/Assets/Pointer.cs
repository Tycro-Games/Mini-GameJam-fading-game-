using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float offset;
    private float currentAngle = 90f;

    private void Update ()
    {
        transform.position = target.position + transform.up * offset;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Vector2 dir = (mousePos - (Vector2)transform.parent.position).normalized;

        transform.rotation = Quaternion.LookRotation (Vector3.forward, dir);
    }

}
