using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EnemiesSpawningManager
{
    public static UnityEvent OnEnemySpawn;
    private static List<EnemySpawner> currentSpawners = new List<EnemySpawner> ();

    public static Transform EnemySpawnersParent { get; set; } = null;

    static bool CheckForNull ()
    {
        if (currentSpawners.Count == 0)
            return true;
        return false;
    }
    static bool CheckForNull (EnemySpawner spawner)
    {
        if (currentSpawners.Contains (spawner))
            return false;
        return true;
    }
    public static void EverySpawnerAct (GameObject enemyPrefab)
    {
        if (CheckForNull ())
        {
            Debug.Log ("Manager without Spawners");
            return;
        }
        foreach (EnemySpawner spawner in currentSpawners)
        {
            spawner.Spawn (enemyPrefab);
        }
    }

    #region static
    public static void SpawnerAct (EnemySpawner spawner, GameObject enemyPrefab)
    {
        if (CheckForNull (spawner))
        {
            Debug.Log ("Manager without Spawners");
            return;
        }
        spawner.Spawn (enemyPrefab);
    }
    public static void DeleteASpawner (EnemySpawner enemySpawner)
    {
        currentSpawners.Remove (enemySpawner);
        Object.Destroy (enemySpawner.gameObject);

    }
    public static void AddASpawner (Vector2 pos, GameObject Spawner)
    {
        GameObject enemySpawnerGameObject = Object.Instantiate (Spawner, pos, Quaternion.identity);
        enemySpawnerGameObject.transform.SetParent (EnemySpawnersParent);

        EnemySpawner enemySpawner = enemySpawnerGameObject.GetComponent<EnemySpawner> ();
        currentSpawners.Add (enemySpawner);
    }
    #endregion
}
