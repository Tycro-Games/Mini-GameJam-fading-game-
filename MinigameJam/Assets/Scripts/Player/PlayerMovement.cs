using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField]
    private Transform transformToTurn = null;
    [SerializeField]
    private float RotationSpeed = 10.0f;
    [SerializeField]
    private float speedMovement = 0.0f;
    Rigidbody2D rb;

    //Input
    private Vector2 movement;
    private  Vector2 move;
   public Vector2 GetMovement ()
    {
        return movement;
    }
    void Start ()
    {


        rb = GetComponent<Rigidbody2D> ();

        StartCoroutine (Rotate (transformToTurn));

    }
    private void FixedUpdate ()
    {
        Move ();
    }
    public void SetMovement (InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2> ();
    }
    private void Move ()
    {
         move = movement;
        move *= Time.fixedDeltaTime * speedMovement;

        rb.MovePosition (rb.position + move);

    }
    IEnumerator Rotate (Transform transformToRotate)
    {

        Transform previousTransform = transformToRotate;//save the transform

        PlayerInput that = GetComponentInParent<PlayerInput> ();//ref to the player input

        while (true)
        {
            Vector2 dir = (CursorController.MousePosition () -(Vector2) transform.position).normalized;
            Quaternion newRotation = Quaternion.LookRotation (dir, transform.up);

            transformToRotate.rotation = Quaternion.RotateTowards (previousTransform.rotation, newRotation, RotationSpeed);

            transformToRotate.RotateAround (transform.position, Vector3.forward, Vector2.SignedAngle (transformToRotate.localPosition,dir));


            yield return null;
        }
    }
  

}
