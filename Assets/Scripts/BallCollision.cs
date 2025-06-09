using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private string newBallDirection;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag != "ball")
        {
            return;
        }

        GameObject gameObject = collider2D.gameObject;

        if (newBallDirection == "right")
        {
            gameObject.transform.position = new Vector3(transform.position.x + transform.lossyScale.x / 2 + gameObject.transform.lossyScale.x / 2, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (newBallDirection == "left")
        {
            gameObject.transform.position = new Vector3(transform.position.x - transform.lossyScale.x / 2 - gameObject.transform.lossyScale.x / 2, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        gameObject.GetComponent<Ball>().SetRandomDirection(newBallDirection);
    }
}
