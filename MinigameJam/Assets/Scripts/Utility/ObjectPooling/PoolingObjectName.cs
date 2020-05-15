using UnityEngine;

public class PoolingObjectName : MonoBehaviour
{
    [SerializeField]
    private string entryName = "Test";
    private void Awake ()
    {
        if (entryName == "Test")
        {
            entryName = entryName.GetHashCode ().ToString ();
            Debug.Log (entryName);
        }
    }
    public string EntryName
    {
        get
        {

            return entryName;
        }
    }
}
