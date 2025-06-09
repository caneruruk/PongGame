using UnityEngine;

[ExecuteAlways]
public class MiddleLine : MonoBehaviour
{
    void Start()
    {
        CameraBorders cameraBorders = new CameraBorders();
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, new Vector3(0, cameraBorders.minY(), 0));
        lineRenderer.SetPosition(1, new Vector3(0, cameraBorders.maxY(), 0));
    }
}
