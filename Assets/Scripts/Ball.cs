using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float pace;
    [SerializeField] private Vector3 direction;
    private float minY;
    private float maxY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float halfHeight = Camera.main.orthographicSize;
        Vector3 cameraPosition = Camera.main.transform.position;

        maxY = cameraPosition.y + halfHeight;
        minY = cameraPosition.y - halfHeight;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * pace * Time.deltaTime;

        // Stay in boundaries
        if (transform.position.y - transform.lossyScale.y / 2 < minY)
        {
            transform.position = new Vector3(transform.position.x, minY + transform.lossyScale.y / 2, transform.position.z);
            direction.y = -direction.y;
        }

        if (transform.position.y + transform.lossyScale.y / 2 > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY - transform.lossyScale.y / 2, transform.position.z);
            direction.y = -direction.y;
        }
    }
}
