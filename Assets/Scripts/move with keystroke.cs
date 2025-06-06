using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveWithKeystoke : MonoBehaviour
{
    [SerializeField] private Key key;
    [SerializeField] private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[key].isPressed)
        {
            transform.position += velocity * Time.deltaTime;
        }
    }
}
