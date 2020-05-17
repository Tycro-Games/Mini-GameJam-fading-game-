using UnityEngine;
[RequireComponent (typeof (SpriteRenderer))]
public class WeaponPointer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight;
    [SerializeField]
    private Sprite[] Sprites = null;

    [SerializeField]
    private Transform pos = null;

    private int symetryAngle = 0;

    private Pointer effect;
    private void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();

        effect = GetComponentInChildren<Pointer> ();
        symetryAngle = 360 / Sprites.Length;
    }
    void Update ()
    {
        transform.position = pos.position;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Vector2 dir = (mousePos - (Vector2)transform.parent.position).normalized;

        if (transform.parent.position.x < mousePos.x)
            isFacingRight = true;
        else
            isFacingRight = false;

        float angle = Vector2.Angle (Vector2.up, dir);

        int index = Mathf.RoundToInt (angle / symetryAngle);

        
        if (index == 0)
            spriteRenderer.sprite = Sprites[index];
        else
        {
            if (!isFacingRight)
                spriteRenderer.sprite = Sprites[index];
            else
            {
                spriteRenderer.sprite = Sprites[Sprites.Length - index];
            }
        }
    }
}
