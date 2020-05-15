using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawnersSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Spawner;
    [SerializeField]
    private float range = 5.0f;
    public void ChangeSpawner (GameObject newSpawner)
    {
        Spawner = newSpawner;
    }
    public void AddSpawners ()
    {
        EnemiesSpawningManager.AddASpawner (Random.insideUnitCircle * range, Spawner);
    }
}
