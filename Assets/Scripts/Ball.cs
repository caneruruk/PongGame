using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float pace;
    [SerializeField] private Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * pace * Time.deltaTime;
    }
}
