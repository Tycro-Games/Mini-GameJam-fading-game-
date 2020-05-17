using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFinished : MonoBehaviour
{
    public static void GetUpgrade (Stats stats)
    {
        BulletSpawner.bonus.bonusFirerate += stats.fireRate;
        BulletSpawner.bonus.bonusDamage += stats.Damage;
        
    }
}
