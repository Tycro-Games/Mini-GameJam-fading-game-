using UnityEngine;

public static class StaticInfo
{
    private static Vector3 playerPos;
    private static Vector2 velocityOfPlayer;
    public static Vector3 PlayerPos
    {
        get
        {
            return playerPos;
        }
    }
    public static Vector2 VelocityOfPlayer
    {
        get
        {
            return velocityOfPlayer;
        }
    }

    public static void GetPos (Transform transform)
    {
        playerPos = transform.position;
    }
    public static void GetVeloc (Vector2 veloc)
    {
        velocityOfPlayer = veloc;
    }
}
