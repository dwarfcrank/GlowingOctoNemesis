using UnityEngine;
using System.Collections;

public class WeaponPickup : Pickup {

    public GameObject weapon;

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
		
		//inventory lisäyksen testailua
		//var inv = GameObject.FindGameObjectWithTag("WeaponInventory");
		//var wInv = inv.GetComponent<WeaponInventory>();
		//if(wInv == null) return;
		
		//wInv.addWeaponToInv((int)WeaponInventory.WeaponType.RIFLE, weapon);

		weapslot.addWeaponToInv((int)WeaponInventory.WeaponType.ROCKET_LAUNCHER, weapon);
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
