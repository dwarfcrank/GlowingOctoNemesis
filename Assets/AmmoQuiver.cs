using UnityEngine;
using System.Collections;

public class AmmoQuiver : MonoBehaviour
{
    //asdfasdf
    public int bulletCount = 500;
    public int rocketCount = 10;
    public string curWeapon = "";

    WeaponSlot slot;


    public int getCurrentWeaponAmmoCount()
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
