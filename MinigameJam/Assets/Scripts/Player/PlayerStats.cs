using System.Collections;
using UnityEngine;

public class PlayerStats : CommonStats, IHitable
{
    [SerializeField]
    private float UntilNextHit = .5f;
    [SerializeField]
    private bool immortal = false;

    //auxiliary
    public static bool atacked = false;
    private float currentTime = 0.0f;
    private float finishTime = 0.0f;


    private void Update ()
    {
        if (atacked)
        {
            currentTime += Time.deltaTime;
            if (currentTime > finishTime)
                atacked = false;
        }
    }
    public void Immortal ()
    {
        immortal = !immortal;
    }
    private void OnEnable ()
    {
        BaseEnemy.OnHit += TakeDamage;

    }
    private void OnDisable ()
    {
        BaseEnemy.OnHit -= TakeDamage;

    }
    public void TakeDamage (int dg)
    {
        if (!immortal)
        {
            if (atacked)
            {
                return;
            }
            else
            {
                //time staff
                atacked = true;

                currentTime = Time.time;
                finishTime = Time.time + UntilNextHit;

                //health staff
                HP -= dg;
                Debug.Log (HP);

                if (HP <= 0)
                    Die ();
            }
        }
    }



    public void Die ()
    {
        PoolingObjectsSystem.Destroy (gameObject);
    }
}