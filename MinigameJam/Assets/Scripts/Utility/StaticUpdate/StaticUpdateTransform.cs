using UnityEngine;

public class StaticUpdateTransform : MonoBehaviour
{
    PlayerMovement movement;
    private void Start ()
    {
        movement = GetComponent<PlayerMovement> ();
    }
    private void Update ()
    {
        StaticInfo.GetPos (transform);
        StaticInfo.GetVeloc (movement.GetMovement());
    }


}
