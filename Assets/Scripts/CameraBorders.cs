using UnityEngine;

public class CameraBorders
{
    public float minY()
    {
        return Camera.main.transform.position.y - Camera.main.orthographicSize;
    }

    public float maxY()
    {
        return Camera.main.transform.position.y + Camera.main.orthographicSize;
    }

    public float minX()
    {
        return Camera.main.transform.position.x - halfWidth();
    }

    public float maxX()
    {
        return Camera.main.transform.position.x + halfWidth();
    }

    private float halfWidth()
    {
        return Camera.main.orthographicSize * Camera.main.aspect;
    }
}