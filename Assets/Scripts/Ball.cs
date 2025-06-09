using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private float pace;
    [SerializeField] private float initialDirectionYMax = 1;
    [SerializeField] private float initialDirectionYMin = -1;
    [SerializeField] private string initialDirection = "left";
    private Vector3 directionVector;
    private CameraBorders cameraBorders = new CameraBorders();
    [SerializeField] private UnityEvent goneOutFromLeft;
    [SerializeField] private UnityEvent goneOutFromRight;
    private bool isStop = true;
    private float isStopPassedTime = 0;
    [SerializeField] private float isStopDelayTime = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetRandomDirection(initialDirection);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop)
        {
            isStopPassedTime += Time.deltaTime;

            if (isStopPassedTime >= isStopDelayTime)
            {
                isStop = false;
                isStopPassedTime = 0;
            }
        }
        else
        {
            transform.position += directionVector * pace * Time.deltaTime;
        }

        // Stay in boundaries
        if (transform.position.y - transform.lossyScale.y / 2 < cameraBorders.minY())
        {
            transform.position = new Vector3(transform.position.x, cameraBorders.minY() + transform.lossyScale.y / 2, transform.position.z);
            directionVector.y = -directionVector.y;
        }

        if (transform.position.y + transform.lossyScale.y / 2 > cameraBorders.maxY())
        {
            transform.position = new Vector3(transform.position.x, cameraBorders.maxY() - transform.lossyScale.y / 2, transform.position.z);
            directionVector.y = -directionVector.y;
        }

        // Reset when there is a point
        if (transform.position.x - transform.lossyScale.x / 2 < cameraBorders.minX())
        {
            goneOutFromLeft.Invoke();

            transform.position = Vector3.zero;
            SetRandomDirection("right");

            isStop = true;
        }

        if (transform.position.x + transform.lossyScale.x / 2 > cameraBorders.maxX())
        {
            goneOutFromRight.Invoke();

            transform.position = Vector3.zero;
            SetRandomDirection("left");

            isStop = true;
        }
    }

    public void SetRandomDirection(string direction)
    {
        if (direction == "left")
        {
            directionVector = new Vector3(-1, Random.Range(initialDirectionYMin, initialDirectionYMax), 0).normalized;
        }

        if (direction == "right")
        {
            directionVector = new Vector3(1, Random.Range(initialDirectionYMin, initialDirectionYMax), 0).normalized;
        }
    }
}
