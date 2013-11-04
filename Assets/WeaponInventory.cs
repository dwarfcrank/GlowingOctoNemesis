using UnityEngine;
using System;
using System.Collections;


public class WeaponInventory : MonoBehaviour {

	public enum WeaponType {
		RIFLE,
		ROCKET_LAUNCHER
	}
	
	bool[] inventory;
	GameObject[] weaps;
	
	// Use this for initialization
	void Start () {
		Debug.Log ("startattud");
		inventory = new bool[Enum.GetNames(typeof(WeaponType)).Length];
		inventory[(int)WeaponType.RIFLE] = true;
		weaps = new GameObject[Enum.GetNames(typeof(WeaponType)).Length];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void addWeaponToInv(int weapon, GameObject WeaponPrefab){
		inventory[weapon] = true;
		Debug.Log ("lisäys doned, weapon nro: " + weapon);
		weaps[weapon] = WeaponPrefab;
		Debug.Log ("prefab: " + weaps[weapon].name);
	}
	
	public bool weaponUnlocked(int weapon){
		if(inventory[weapon]){
			return true;
		}
		return false;
	}

	/*
	public void switchWeapon(int weapon){
		if(!weaponUnlocked(weapon)){
			return;
		}
		
		
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
	}
	
	
	public void SetWeapon(GameObject WeaponPrefab)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        currentWeapon = (GameObject)Instantiate(WeaponPrefab, transform.position, transform.rotation);
        currentWeapon.transform.parent = transform;

        var trigger = currentWeapon.GetComponent<TriggerOnMouseOrJoystick>();
        var player = GameObject.FindGameObjectWithTag("PlayerAnim");

        trigger.mouseDownSignals.receivers[1]   = new ReceiverItem() { receiver = player, action = "OnStartFire" };
        trigger.mouseUpSignals.receivers[1] = new ReceiverItem() { receiver = player, action = "OnStopFire" };
    }
	*/
	
}
