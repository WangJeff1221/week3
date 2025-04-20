using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 3f; 
    private int currentLane = 1; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentLane < 2)
        {
            currentLane++;
            MoveLane();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentLane > 0)
        {
            currentLane--;
            MoveLane();
        }
    }

    void MoveLane()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = (currentLane - 1) * laneDistance; 
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
        else if (other.CompareTag("Coin"))
        {
            GameManager.Instance.AddCoin();
            Destroy(other.gameObject);
        }
    }
}
