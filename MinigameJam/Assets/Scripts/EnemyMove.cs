using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform point;
    Vector2 dir;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float stopDist = .5f;
    private void Start ()
    {
        point = GameObject.FindGameObjectWithTag ("Finish").transform;
        dir = (point.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update ()
    {
        float dist = Vector2.Distance (transform.position, point.position);
        if (dist > stopDist)
            transform.Translate (dir * Time.deltaTime * speed);
        else
        {
            HasBonus bonus = GetComponent<HasBonus> ();

            if (bonus != null)
                bonus.GetUp ();

            Destroy (gameObject);           
        }
    }
}
