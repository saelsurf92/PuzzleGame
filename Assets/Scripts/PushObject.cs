using UnityEngine;

public class TriggerObjectPusher : MonoBehaviour
{
    public float pushForce = 6f; // Adjustable push force
    public float pushCooldown = 0.5f;
    private float lastPushTime = 0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("TriggerObject"))
        {
            Debug.Log("Collided with: " + hit.gameObject.name); // Check if collision happens
            
            Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();

            if (rb != null && Time.time > lastPushTime + pushCooldown)
            {
                rb.isKinematic = false; // Enable physics
                rb.WakeUp(); // Ensure Rigidbody is awake

                Vector3 pushDirection = transform.forward; // Push forward
                rb.linearVelocity = Vector3.zero; // Reset velocity
                rb.AddForce(pushDirection * pushForce, ForceMode.Impulse); // Apply force

                lastPushTime = Time.time; // Cooldown
                Debug.Log("Object pushed: " + hit.gameObject.name);
            }
        }
    }
}


