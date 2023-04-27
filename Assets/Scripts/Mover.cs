using UnityEngine;

/**
 * This component moves the object at a constant velocity.
 */
public class Mover: MonoBehaviour {
    [Tooltip("Movement vector in meters per second")]
    [SerializeField] Vector3 velocity;

    void Update() {
        transform.position += velocity * Time.deltaTime;
    }

    public void SetVelocity(Vector3 newVelocity) {
        this.velocity = newVelocity;
    }
    
}
