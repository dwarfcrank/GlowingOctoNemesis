using UnityEngine;
using System.Collections;

public class AmmoQuiver : MonoBehaviour
{
    //asdfasdf
    int bulletCount = 500;
    int rocketCount = 0;
    public string curWeapon = "";

    WeaponSlot slot;

	public void AddBulletsToQuiver(int count)
	{
		bulletCount += count;
	}

	public void AddRocketsToQuiver(int count)
	{
		rocketCount += count;
	}

    public int GetCurrentWeaponAmmoCount()
    {
        string weapon = slot.GetCurrentWeaponName();

        curWeapon = weapon;

        switch (weapon)
        {
            case "RocketLauncher(Clone)":
                return rocketCount;
            case "Weapon(Clone)":
                return bulletCount;
        }

        return -1;
    }


	public void ShootCurrentWeapon()
	{
		string weapon = slot.GetCurrentWeaponName();

		curWeapon = weapon;

		switch (weapon)
		{
			case "RocketLauncher(Clone)":
				rocketCount--;
				break;
			case "Weapon(Clone)":
				bulletCount--;
				break;
		}
	}

    // Use this for initialization
    void Start()
    {
        slot = GameObject.FindGameObjectWithTag("WeaponSlot").GetComponent<WeaponSlot>();
        //slot.GetCurrentWeaponName();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
