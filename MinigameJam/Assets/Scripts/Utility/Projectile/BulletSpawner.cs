using UnityEngine;
using UnityEngine.Events;

public struct Bonus
{
    public int bonusDamage;
    public int bonusFirerate;
   public Bonus (int BonusDg=0, int BonusF = 0)
    {
        bonusDamage = BonusDg;
        bonusFirerate = BonusF;
    }
}
public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private ProjectileObjects projectile;
    [SerializeField]
    private Transform projectiles = null;
    [SerializeField]
    private LayerMask CollideableMask = 0;

    [SerializeField]
    private UnityEvent shoot = null;

    public static Bonus bonus=new Bonus();
    private float currentTime = 0.0f;
    public void ChangeProjectile (ProjectileObjects project)
    {
        projectile = project;
    }

    public void Spawn ()
    {
        if (currentTime <= Time.time)
        {
            currentTime = Time.time + 1 / projectile.FirePerSecond;
            currentTime -= bonus.bonusFirerate;
            shoot.Invoke ();

            Projectile projectileInit = Spawner.Spawn (projectile.projectilePrefab, transform, projectiles).GetComponentInChildren<Projectile> ();
            projectileInit.Init (projectile.speed, projectile.damage + bonus.bonusDamage, CollideableMask);
        }
    }
}
