using UnityEngine;
using System.Collections;

public class WeaponPickup : Pickup {

    public GameObject weapon;
	public WeaponSlot.WeaponType WeaponNumber;
    public int RocketCountInPickup = 10;

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
        var slot = GameObject.FindGameObjectWithTag("WeaponSlot");

        if (!slot.transform.IsChildOf(player.transform) || slot.transform.childCount == 0)
        {
            return;
        }

        var weapslot = slot.GetComponent<WeaponSlot>();

        if (weapslot == null)
        {
            return;
        }

        weapslot.SetWeapon(weapon);
		weapslot.addWeaponToInv((int)WeaponNumber, weapon);

		if (WeaponNumber == WeaponSlot.WeaponType.ROCKET_LAUNCHER)
		{
			AmmoQuiver quiver = player.GetComponent<AmmoQuiver>();
			quiver.AddRocketsToQuiver(RocketCountInPickup);
		}
		
        /*var weap = slot.transform.GetChild(0);
        var fire = weap.GetComponent<AutoFire>();

        if (fire == null)
        {
            return;
        }

        fire.frequency *= 2;
        fire.coneAngle *= 5;*/
    }
}
