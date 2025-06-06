using UnityEngine;

public class StayDownTheLine : MonoBehaviour
{
    [SerializeField] private float y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + transform.lossyScale.y / 2 > y)
        {
            transform.position = new Vector3(transform.position.x, y - transform.lossyScale.y / 2, transform.position.z);
        }
    }
}
