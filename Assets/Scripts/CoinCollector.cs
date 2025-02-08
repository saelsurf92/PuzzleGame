using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject); // Destroys the Coin
            Debug.Log("Coin collected!"); // Logs the event
        }
    }
}
