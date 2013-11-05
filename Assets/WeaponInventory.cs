using UnityEngine;
using System;
using System.Collections;


public class WeaponInventory : MonoBehaviour {

	public enum WeaponType {
		RIFLE,
		ROCKET_LAUNCHER
	}
	
	//bool[] inventory;
	GameObject[] weaps;
	
	// Use this for initialization
	void Start () {
		Debug.Log ("startattud");
		//inventory = new bool[Enum.GetNames(typeof(WeaponType)).Length];
		//inventory[(int)WeaponType.RIFLE] = true;
		weaps = new GameObject[Enum.GetNames(typeof(WeaponType)).Length];
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown("1")) 
		{
    		switchWeapon((int)WeaponType.RIFLE);
		}

		else if (Input.GetKeyDown("2")) 
		{
    		switchWeapon((int)WeaponType.ROCKET_LAUNCHER);
		}
		
	}
	
	public void addWeaponToInv(int weapon, GameObject WeaponPrefab){
		//inventory[weapon] = true;
		weaps[weapon] = WeaponPrefab;
		Debug.Log ("lisäys doned, weapon nro: " + weapon);
		Debug.Log ("prefab: " + weaps[weapon].name);
		
	}
	
	public bool weaponUnlocked(int weapon){
		/*
		if(inventory[weapon]){
			return true;
		}
		return false;
		*/
		
		if(weaps[weapon] == null){
			return false;
		}
		return true;
	}

	public void switchWeapon(int weapon){
		Debug.Log ("koitetaan vaihtaa");
		if(!weaponUnlocked(weapon)){
			Debug.Log ("nope :(");
			return;
		}
		Debug.Log ("yep :D");
		var slot = GameObject.FindGameObjectWithTag("WeaponSlot");
				
		/*
        if (!slot.transform.IsChildOf(player.transform) || slot.transform.childCount == 0)
        {
            return;
        }
		*/ 
		 
        var weapslot = slot.GetComponent<WeaponSlot>();

        if (weapslot == null)
        {
			Debug.Log ("weapslot null :(");
            return;
        }
		
		Debug.Log ("vaihdetaan pyssy :D");
        weapslot.SetWeapon(weaps[weapon]);
	}

	
}
