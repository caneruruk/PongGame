using UnityEngine;
using UnityEngine.InputSystem;

public class Rod : MonoBehaviour
{
    [SerializeField] private Key upKey;
    [SerializeField] private Key downKey;
    [SerializeField] private float pace;
    private CameraBorders cameraBorders = new CameraBorders();
    
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
        if (transform.position.y - transform.lossyScale.y / 2 < cameraBorders.minY())
        {
            transform.position = new Vector3(transform.position.x, cameraBorders.minY() + transform.lossyScale.y / 2, transform.position.z);
        }

        if (transform.position.y + transform.lossyScale.y / 2 > cameraBorders.maxY())
        {
            transform.position = new Vector3(transform.position.x, cameraBorders.maxY() - transform.lossyScale.y / 2, transform.position.z);
        }
    }
}
