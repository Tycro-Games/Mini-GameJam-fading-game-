using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static Transform playerTransform = null;


    private BaseEnemy atack;

    [SerializeField]
    private bool Shooting = false;
    [SerializeField]
    private bool damageProximity = false;

    [Header ("RepathSpeeds")]
    [SerializeField]
    private float RepathSpeed = 0.75f;
    void Start()
    {
        atack = GetComponentInChildren<BaseEnemy> ();

        atack.Init (Shooting, damageProximity, RepathSpeed);
    }
}
