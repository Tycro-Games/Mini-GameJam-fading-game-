using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFinished : MonoBehaviour
{
    public static int number = 0;
    private void Start ()
    {
        number = 0;
    }
    public static void GetUpgrade (Stats stats)
    {
        BulletSpawner.bonus.bonusFirerate += stats.fireRate;
        BulletSpawner.bonus.bonusDamage += stats.Damage;
    }
    public static void Numberup (int nr)
    {
        number += nr;
        if (number < 0)
            number = 0;
    }
}
