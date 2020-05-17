using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform point;
    Vector2 dir;

    private float speed = 0;
    [SerializeField]
    private float speedMin = 0;
    [SerializeField]
    private float speedMax = 0;
    [SerializeField]
    private float stopDist = .5f;

    [SerializeField]
    private bool sinUse = false;

    [SerializeField]
    private bool RandomSin = false;
    private FadeOut fade = null;

    [SerializeField]
    private float maxSin = 1;
    [SerializeField]
    private float minSin = .25f;

    private Animator anim;

    private float RandomStart;

    private bool AddHumans = false;
    private void Start ()
    {
        if (RandomSin)
            sinUse = Mathf.RoundToInt (Random.value) == 1 ? false : true;

        speed = Random.Range (speedMin, speedMax);

        anim = GetComponentInChildren<Animator> ();

        anim.SetFloat ("Speed", speed);

        point = GameObject.FindGameObjectWithTag ("Finish").transform;

        fade = GetComponentInChildren<FadeOut> ();

        dir = (point.position - transform.position).normalized;

        RandomStart = Random.Range (0, 100);
    }



    // Update is called once per frame
    void Update ()
    {

        float dist = Vector2.Distance (transform.position, point.position);
        if (dist > stopDist)
        {
            RandomStart += Time.deltaTime;
            
            if (!sinUse)
            {
                transform.Translate (dir * Time.deltaTime * speed);
                anim.SetFloat ("Speed", speed);
            }
            else
            {

                transform.Translate (dir * Time.deltaTime * speed * Mathf.Clamp (Mathf.Sin (RandomStart), minSin, maxSin));
                anim.SetFloat ("Speed", speed * Mathf.Clamp (Mathf.Sin (RandomStart), minSin, maxSin));
            }
        }
        else
        {
            HasBonus bonus = GetComponent<HasBonus> ();

            if (bonus != null)
                bonus.GetUp ();

            fade.StartCoroutine (fade.Fade ());

            fade.gameObject.transform.SetParent(null);

            
            Destroy (gameObject);
        }
        
    }
    public IEnumerator Hit (float time=.5f)
    {
        float tSpeed = speed;
        speed = 0.1f;
        yield return new WaitForSeconds (time);
        speed = tSpeed;
    }
}
