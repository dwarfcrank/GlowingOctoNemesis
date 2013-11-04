using UnityEngine;
using System.Collections;

public class WeaponSlot : MonoBehaviour {

    public GameObject defaultWeaponPrefab;

    void Start()
    {
        SetWeapon(defaultWeaponPrefab);
    }
    
    public void SetWeapon(GameObject WeaponPrefab)
    {
        var weapon = (GameObject)Instantiate(WeaponPrefab, transform.position, transform.rotation);
        weapon.transform.parent = transform;

        var trigger = weapon.GetComponent<TriggerOnMouseOrJoystick>();
        var player = GameObject.FindGameObjectWithTag("PlayerAnim");

        trigger.mouseDownSignals.receivers[1]   = new ReceiverItem() { receiver = player, action = "OnStartFire" };
        trigger.mouseUpSignals.receivers[1] = new ReceiverItem() { receiver = player, action = "OnStopFire" };
    }

    void Update()
    {
    }
}
