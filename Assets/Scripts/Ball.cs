using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float pace;
    [SerializeField] private float initialDirectionYMax = 1;
    [SerializeField] private float initialDirectionYMin = -1;
    [SerializeField] private string initialDirection = "left";
    private Vector3 directionVector;
    private float minY;
    private float maxY;
    private float maxX;
    private float minX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float halfHeight = Camera.main.orthographicSize;
        Vector3 cameraPosition = Camera.main.transform.position;

        maxY = cameraPosition.y + halfHeight;
        minY = cameraPosition.y - halfHeight;

        float halfWidth = halfHeight * Camera.main.aspect;

        maxX = cameraPosition.x + halfWidth;
        minX = cameraPosition.x - halfWidth;

        SetRandomDirection(initialDirection);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += directionVector * pace * Time.deltaTime;

        // Stay in boundaries
        if (transform.position.y - transform.lossyScale.y / 2 < minY)
        {
            transform.position = new Vector3(transform.position.x, minY + transform.lossyScale.y / 2, transform.position.z);
            directionVector.y = -directionVector.y;
        }

        if (transform.position.y + transform.lossyScale.y / 2 > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY - transform.lossyScale.y / 2, transform.position.z);
            directionVector.y = -directionVector.y;
        }

        // Reset when there is a point
        if (transform.position.x - transform.lossyScale.x / 2 < minX)
        {
            transform.position = Vector3.zero;
            SetRandomDirection("right");
        }

        if (transform.position.x + transform.lossyScale.x / 2 > maxX)
        {
            transform.position = Vector3.zero;
            SetRandomDirection("left");
        }
    }

    public void SetRandomDirection(string direction)
    {
        if (direction == "left")
        {
            directionVector = new Vector3(-1, Random.Range(initialDirectionYMin, initialDirectionYMax), 0);
        }

        if (direction == "right")
        {
            directionVector = new Vector3(1, Random.Range(initialDirectionYMin, initialDirectionYMax), 0);
        }
    }
}
