using UnityEngine;

public class HasBonus : MonoBehaviour
{
    [SerializeField]
    private Stats stats;
    public void GetUp ()
    {
        IsFinished.GetUpgrade (stats);
    }
}
