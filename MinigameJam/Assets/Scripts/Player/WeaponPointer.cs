using UnityEngine;

public class WeaponPointer : MonoBehaviour
{

    private bool facingRight = true;

    private void Update ()
    {
        #region rot
        Vector2 dir = (CursorController.MousePosition () - (Vector2)transform.position).normalized;

        Quaternion newPos = Quaternion.LookRotation (Vector3.forward, dir);

        transform.rotation = newPos;
        #endregion

        #region checkFlip
        float currentX = transform.position.x;
        float thatX = CursorController.MousePosition ().x;
        if (thatX < currentX && facingRight)
            Flip ();
        else if (thatX > currentX && !facingRight)
            Flip ();
        #endregion
    }
    public void Flip ()
    {
        facingRight = !facingRight;
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
