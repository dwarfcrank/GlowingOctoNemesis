using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void OnTriggerEnter(Collider other)
    {
        var pickup = other.gameObject.GetComponent<Pickup>();

        pickup.ApplyEffect(gameObject);

        Destroy(other.gameObject);
    }
}
