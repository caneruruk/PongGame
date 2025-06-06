using UnityEngine;
using UnityEngine.InputSystem;

public class Rod : MonoBehaviour
{
    [SerializeField] private Key upKey;
    [SerializeField] private Key downKey;
    [SerializeField] private float pace;
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
        // Movement
        if (Keyboard.current[upKey].isPressed)
        {
            transform.position += Vector3.up * pace * Time.deltaTime;
        }

        if (Keyboard.current[downKey].isPressed)
        {
            transform.position += Vector3.down * pace * Time.deltaTime;
        }

        // Stay in boundaries
        if (transform.position.y - transform.lossyScale.y / 2 < minY)
        {
            transform.position = new Vector3(transform.position.x, minY + transform.lossyScale.y / 2, transform.position.z);
        }

        if (transform.position.y + transform.lossyScale.y / 2 > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY - transform.lossyScale.y / 2, transform.position.z);
        }
    }
}
