using UnityEngine;
using System.Collections;

public class AmmoPickup : Pickup {

    public int bulletsInPickup = 50;
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
        AmmoQuiver quiver = player.GetComponent<AmmoQuiver>();
		quiver.AddBulletsToQuiver(bulletsInPickup);
    }
	
}

