using System.Collections.Generic;
using UnityEngine;

public class PoolingEntry
{
    Queue<GameObject> entries;
    public PoolingEntry ()
    {
        entries = new Queue<GameObject> ();
    }
    public GameObject Instantiate (GameObject prefab, Vector3 pos, Quaternion rot)
    {
        if (entries.Count == 0)
        {
            return Object.Instantiate (prefab, pos, rot);
        }
        else
        {
            GameObject objectToAdd = entries.Dequeue ();

            objectToAdd.SetActive (true);
            objectToAdd.transform.position = pos;
            objectToAdd.transform.rotation = rot;
            
            

            return objectToAdd;
        }
    }
    public void Destroy (GameObject objectToAdd)
    {
        entries.Enqueue (objectToAdd);
        objectToAdd.SetActive (false);
        
    }
}
