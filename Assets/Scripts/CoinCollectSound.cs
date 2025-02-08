using UnityEngine;

public class CoinCollectSound : MonoBehaviour
{
    public AudioClip coinSound; // Assign the audio clip in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            if (coinSound != null)
            {
                audioSource.PlayOneShot(coinSound); // Play the coin collection sound
            }
            Destroy(other.gameObject); // Destroy the coin
            Debug.Log("Coin collected with sound!");
        }
    }
}