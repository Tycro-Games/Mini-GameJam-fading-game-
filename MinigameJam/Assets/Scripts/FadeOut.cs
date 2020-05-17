using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    SpriteRenderer sprite;

  
    private Health hp;

    [SerializeField]
    private float dg = .34f;

    [SerializeField]
    private bool dag = false;
    private void Start ()
    {
        hp = FindObjectOfType<Health> ();
        sprite = GetComponent<SpriteRenderer> ();
    }
    public IEnumerator Fade ()
    {
        Color opaq = sprite.color;
        Vector3 scale = transform.parent.localScale;
        if (dag)
            hp.ChangeInHealth (dg);
        else
            hp.ADDInHealth (dg);

        while (opaq.a > 0)
        {
            yield return null;
            if (scale.x > 0)
                scale.x -= Time.deltaTime;
            else if (scale.x < 0)
                scale.x += Time.deltaTime;

            scale.y -= Time.deltaTime;
            scale.z -= Time.deltaTime;

            transform.localScale = scale;
            opaq.a -= Time.deltaTime;
            sprite.color = opaq;

        }
       
        Destroy (gameObject);
    }
}
