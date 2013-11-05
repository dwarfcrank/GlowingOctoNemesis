using UnityEngine;
using System;
using System.Collections;

public class WeaponSlot : MonoBehaviour {

    public GameObject defaultWeaponPrefab;

    private GameObject currentWeapon;
	
	GameObject[] weaps;
	
	public enum WeaponType {
		RIFLE,
		ROCKET_LAUNCHER
	}
	
    void Start()
    {
        currentWeapon = null;

        SetWeapon(defaultWeaponPrefab);
		weaps = new GameObject[Enum.GetNames(typeof(WeaponType)).Length];
		weaps[(int)WeaponType.RIFLE] = defaultWeaponPrefab;
    }
    
    public void SetWeapon(GameObject WeaponPrefab)
    {
        if (currentWeapon != null)
        {
			currentWeapon.SetActive(false);
            //Destroy(currentWeapon);
        }

        currentWeapon = (GameObject)Instantiate(WeaponPrefab, transform.position, transform.rotation);
        currentWeapon.transform.parent = transform;

        var trigger = currentWeapon.GetComponent<TriggerOnMouseOrJoystick>();
        var player = GameObject.FindGameObjectWithTag("PlayerAnim");

        trigger.mouseDownSignals.receivers[1]   = new ReceiverItem() { receiver = player, action = "OnStartFire" };
        trigger.mouseUpSignals.receivers[1] = new ReceiverItem() { receiver = player, action = "OnStopFire" };
    }

    void Update()
    {
		if (Input.GetKeyDown("1")) 
		{
    		switchWeapon((int)WeaponType.RIFLE);
		}

		else if (Input.GetKeyDown("2")) 
		{
    		switchWeapon((int)WeaponType.ROCKET_LAUNCHER);
		}
		
    }
	
	public void addWeaponToInv(int weapon, GameObject WeaponPrefab)
	{
		weaps[weapon] = WeaponPrefab;
	}
	
	public bool weaponUnlocked(int weapon)
	{
		if(weaps[weapon] == null){
			return false;
		}
		return true;
	}

	public void switchWeapon(int weapon)
	{
		if(!weaponUnlocked(weapon))
		{
			return;
		}
		var slot = GameObject.FindGameObjectWithTag("WeaponSlot");
				
		var player = GameObject.FindGameObjectWithTag("PlayerAnim");
        if (!slot.transform.IsChildOf(player.transform) || slot.transform.childCount == 0)
        {
            return;
        }
		 
        var weapslot = slot.GetComponent<WeaponSlot>();

        if (weapslot == null)
        {
            return;
        }
		
        weapslot.SetWeapon(weaps[weapon]);
		weaps[weapon].SetActive(true);
	}
	
}
