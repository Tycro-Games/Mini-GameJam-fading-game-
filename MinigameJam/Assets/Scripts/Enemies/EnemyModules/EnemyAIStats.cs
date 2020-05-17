using System.Collections;
using UnityEngine;
[RequireComponent (typeof (Collider2D))]

public class EnemyAIStats : CommonStats, IHitable
{
    [SerializeField]
    private float takePoints = 0.25f;
    //this script kills you

    [SerializeField]
    private GameObject dead = null;


    public void Die ()
    {
        FindObjectOfType<Health> ().ChangeInHealth (takePoints);
        if (transform.childCount > 0)
            transform.DetachChildren ();

        GameObject ob = Instantiate (dead, transform.position, transform.rotation);
        Destroy (ob, 3f);
        GetComponentInParent<EnemyMove> ().Die();
        Destroy (transform.parent.gameObject);
    }
    public void TakeDamage (int dg)
    {
        HP -= dg;
        if (HP <= 0)
            Die ();
    }
}
