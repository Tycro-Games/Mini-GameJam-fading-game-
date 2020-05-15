using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof (SpriteRenderer))]
public class CursorController : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField]
    private float radius = 5.0f;
    private void Start ()
    {
        Cursor.visible = false;
        input = GetComponentInParent<PlayerInput> ();//ref to the player input
    }
    private void Update ()
    {
        if (input.currentControlScheme == "Keyboard+Mouse")
            transform.position = MousePosition ();
    }

    public static Vector2 MousePosition ()
    {
        Vector2 CursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
          return CursorPos;
    }
    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere (transform.position, radius);
    }

}
