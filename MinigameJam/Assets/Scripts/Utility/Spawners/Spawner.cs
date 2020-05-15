using UnityEngine;

public class Spawner
{

    public static GameObject Spawn (GameObject ObjectToSpawn, Transform transform, Transform parentTransform = null)
    {
        GameObject spawnedObject = PoolingObjectsSystem.Instantiate (ObjectToSpawn, transform.position, transform.rotation);

        if (parentTransform!=null)
            spawnedObject.transform.SetParent (parentTransform);
        return spawnedObject;
    }
}