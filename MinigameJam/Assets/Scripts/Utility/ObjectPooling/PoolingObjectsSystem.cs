using System.Collections.Generic;
using UnityEngine;

public class PoolingObjectsSystem
{
    public static Dictionary<string, PoolingEntry> PoolingObjects = new Dictionary<string, PoolingEntry> ();
    public static GameObject Instantiate (GameObject objectToSpawn, Vector3 pos, Quaternion rotation)
    {
        PoolingObjectName name = objectToSpawn.GetComponent<PoolingObjectName> ();
        if (name != null)
        {
            string entryName = name.EntryName;
            PoolingEntry actualEntry = null;

            if (PoolingObjects.ContainsKey (entryName))
            {
                actualEntry = PoolingObjects[entryName];
            }
            else
            {
                actualEntry = new PoolingEntry ();
            }
            return actualEntry.Instantiate (objectToSpawn, pos, rotation);
        }
        else
        {
            return Object.Instantiate (objectToSpawn, pos, rotation);
        }
    }
    public static void Destroy (GameObject objectToDestroy)
    {
        PoolingObjectName name = objectToDestroy.GetComponent<PoolingObjectName> ();
        if (name != null)
        {
            string entryName = name.EntryName;
            PoolingEntry actualEntry = null;
            if (PoolingObjects.ContainsKey (entryName))
            {
                actualEntry = PoolingObjects[entryName];
            }
            else
            {
                actualEntry = new PoolingEntry ();
                PoolingObjects.Add (entryName, actualEntry);
            }
            actualEntry.Destroy (objectToDestroy);
        }
        else
        {
            Object.Destroy (objectToDestroy);
        }
    }
}
