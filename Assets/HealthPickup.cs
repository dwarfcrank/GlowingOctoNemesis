using UnityEngine;
using System.Collections;

public class HealthPickup : Pickup {
	
	// Use this for initialization
	protected override void Start()
	{
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update()
    {
        base.Update();
    }

	    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<Health>().addHealth(50);
		Destroy(transform.parent.gameObject);
    }
	
}

