using UnityEngine;
using System;
using System.Collections;


public class WeaponInventory : MonoBehaviour {

	public enum WeaponType {
		RIFLE,
		ROCKET_LAUNCHER
	}
	
	bool[] inventory;
	
	// Use this for initialization
	void Start () {
		Debug.Log ("startattud");
		inventory = new bool[Enum.GetNames(typeof(WeaponType)).Length];
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void addWeaponToInv(int weapon){
		inventory[weapon] = true;
		Debug.Log ("lisäys doned");
	}
	
	public bool weaponUnlocked(int weapon){
		if(inventory[weapon]){
			return true;
		}
		return false;
	}
	
	public void switchWeapon(int weapon){
		
	}
	
	
}
