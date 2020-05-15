using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]

public class EnemyAIStats : CommonStats, IHitable
{
    //this script kills you
    public void Die ()
    {
        Destroy (transform.parent.gameObject);
    }
    public void TakeDamage (int dg)
    {
        HP -= dg;
        if (HP <= 0)
            Die ();
    }
}
