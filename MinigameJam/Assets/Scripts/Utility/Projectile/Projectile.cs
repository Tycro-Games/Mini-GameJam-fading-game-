using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
[RequireComponent (typeof (CircleCollider2D))]
public class Projectile : MonoBehaviour
{
    private LayerMask collideableLayer;
    private float speed = 10.0f;
    private float velocity = 0.0f;

    [SerializeField]
    private float thickness = 0.25f;

    [SerializeField]
    private bool Explsive = false;
    [SerializeField]
    private float explosiveRange = 1.0f;

    private int damage;
    private bool destroyed = false;
    private readonly float lifetime = 5.0f;
    [SerializeField]
    private GameObject effect = null;
    [SerializeField]
    private GameObject effectDirt = null;
    public void Init (float Speed, int Damage, LayerMask Collide)
    {
        speed = Speed;
        collideableLayer = Collide;
        damage = Damage;

        destroyed = false;

        CheckStart ();
    }
    private void OnEnable ()
    {
        transform.position = transform.parent.position;
        StartCoroutine (DestroyProjectileTime (lifetime));
    }
    private void Update ()
    {
        velocity = Time.deltaTime * speed;

        transform.Translate (Vector3.forward * velocity, Space.Self);
    }
    private void FixedUpdate ()
    {
        if (!destroyed)
            CheckSoroundings (velocity);
    }
    public void DestroyProjectile ()
    {
        if (transform.parent.gameObject.activeInHierarchy)
        {
            PoolingObjectsSystem.Destroy (transform.parent.gameObject);
            
        }
    }
    public IEnumerator DestroyProjectileTime (float lifetime)
    {
        yield return new WaitForSeconds (lifetime);
        PoolingObjectsSystem.Destroy (transform.parent.gameObject);
    }
    void CheckSoroundings (float veloc)
    {
        RaycastHit2D hit = Physics2D.CircleCast (transform.position, thickness, transform.forward, veloc, collideableLayer);
        if (hit.collider != null)
        {
            
            if (hit.transform.parent.tag == "Human")
            {
                GameObject ef = Instantiate (effect, hit.point, Quaternion.LookRotation (Vector3.forward, hit.normal));
                EnemyMove enemy = hit.transform.GetComponentInParent<EnemyMove> ();
                enemy.StartCoroutine (enemy.Hit ());
                Destroy (ef, 2);
            }
            else
            {
                GameObject ef = Instantiate (effectDirt, hit.point, Quaternion.LookRotation (Vector3.forward, hit.normal));
 
                Destroy (ef, 2);
            }
           
            HitObject (hit.collider, hit.point);
        }
    }
    void takeCol (Collider2D col)
    {
        IHitable hit = col.GetComponent<IHitable> ();
        if (hit != null)
            hit.TakeDamage (damage);
    }
    void HitObject (Collider2D col, Vector2 pointHit)
    {
        takeCol (col);


        if (Explsive)
        {
            Collider2D[] colliders = new Collider2D[10];
            colliders = Physics2D.OverlapCircleAll (transform.position, explosiveRange, collideableLayer);
            if (colliders.Length != 0)
            {
                foreach (Collider2D c in colliders)
                {
                    takeCol (c);
                }
            }
        }
        DestroyProjectile ();
    }

    void CheckStart ()
    {
        Collider2D[] colliders = new Collider2D[10];
        int cols = Physics2D.OverlapCircleNonAlloc (transform.position, thickness, colliders, collideableLayer);
        if (cols > 0)
        {
            HitObject (colliders[0], transform.position);
            destroyed = true;
        }
    }
    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, .5f);
    }
}
