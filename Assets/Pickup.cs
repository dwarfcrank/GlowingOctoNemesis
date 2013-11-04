using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    private float rotation;
    private float originalZ;

    // Use this for initialization
    protected virtual void Start()
    {
        rotation = 0.0f;
        originalZ = transform.position.z;
    }
    
    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, 2.0f));
        transform.Translate(new Vector3(0.0f, 0.0f, Mathf.Sin(rotation * 4.0f) * 0.01f));

        rotation += Time.deltaTime;
    }

    public virtual void ApplyEffect(GameObject player)
    {

    }
}
