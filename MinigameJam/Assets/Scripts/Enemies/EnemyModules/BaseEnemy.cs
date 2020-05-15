using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;

[RequireComponent (typeof (Collider2D))]
public class BaseEnemy : MonoBehaviour
{
    private NavMeshAgent agent = null;
    [SerializeField]
    private Stats stats = null;
    private float TimeBetweenAtacks = .5f;
    [SerializeField]
    private float speedRotation = 180.0f;
    [SerializeField]
    private LayerMask TrueIfFacing = new LayerMask ();
    [SerializeField]
    private bool NeedToFace = false;
    [Header ("Booleans")]
    [SerializeField]
    private bool Non_Moveable = false;
    [SerializeField]
    private bool StopAndShoot = false;

    private void Awake ()
    {
        agent = GetComponentInParent<NavMeshAgent> ();
        enemyTransform = agent.transform;
    }

    private void Update ()
    {
        if (enemyTransform.gameObject.activeInHierarchy)
            agent.SetDestination (StaticInfo.PlayerPos);
    }
    public void Init (bool Shoot, bool Proxy, float repathSpeed)
    {
        //ChangeRepath (repathSpeed);

        StopAllCoroutines ();
        if (Shoot)
        {
            StartCoroutine (AtackRange ());
        }
        if (Proxy)
        {
            StartCoroutine (AtackProximity ());
            damageProxy = true;
        }
    }
    private void OnDisable ()
    {
        StopAllCoroutines ();
    }
    public void ChangeRepath (float speed)
    {

    }

    #region Atack Range


    [Header ("Range")]
    [SerializeField]
    private UnityEvent OnShoot = null;
    [SerializeField]
    private float rangeToShoot = 5.0f;
    [SerializeField]
    private float SpeedOfPrefire = 1.5f;


    private Transform enemyTransform = null;

    public IEnumerator AtackRange ()
    {

        while (OnShoot != null && OnHit != null)
        {

            if (agent.remainingDistance <= rangeToShoot)//in range
            {


                PointPlayer ();

                if (isFacingPlayer () || NeedToFace) //if you face the player shoot
                {
                    agent.isStopped = true;
                    OnShoot.Invoke ();
                }
                else if (!StopAndShoot)
                {
                    agent.isStopped = false;//go to player
                }
            }
            else
                agent.isStopped = false;//go to player

            if (Non_Moveable)
                agent.isStopped = true;
            yield return null;

        }
    }
    bool isFacingPlayer ()
    {

        RaycastHit2D ray = Physics2D.Raycast (enemyTransform.position, enemyTransform.forward, rangeToShoot, TrueIfFacing);
        Debug.DrawRay (enemyTransform.position, enemyTransform.forward * rangeToShoot, Color.blue);
        if (ray.collider != null)
            return true;
        else
            return false;
    }
    void PointPlayer ()
    {
        Vector2 target = (Vector2)StaticInfo.PlayerPos + StaticInfo.VelocityOfPlayer * SpeedOfPrefire;
        Vector2 dir = (target - (Vector2)enemyTransform.position).normalized;

        Debug.DrawLine (enemyTransform.position, (Vector2)enemyTransform.position + dir);

        Quaternion newRot = Quaternion.LookRotation (dir, enemyTransform.up);

        enemyTransform.rotation = Quaternion.RotateTowards (enemyTransform.rotation, newRot, speedRotation * Time.deltaTime);
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere (transform.position, rangeToShoot);
    }
    #endregion

    #region atack proximity
    //Damage PlayerEvent

    public delegate void Onhit (int dg);
    public static event Onhit OnHit;

    [Header ("Damge Proximity")]
    private bool damageProxy;
    private bool inRange = false;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        //Enemies layer can only interact with the player
        inRange = true;
    }
    private void OnTriggerExit2D (Collider2D collision)
    {
        //Enemies layer can only interact with the player
        inRange = false;
    }
    public IEnumerator AtackProximity ()
    {

        while (OnHit != null)
        {

            if (!PlayerStats.atacked && inRange && damageProxy && gameObject.activeInHierarchy)
            //translation: the player cand take damage, is in range and you've set true, the damage proximity bool
            {
                OnHit (stats.Damage);
            }
            yield return new WaitForSeconds (TimeBetweenAtacks);
        }

    }
    #endregion
}
