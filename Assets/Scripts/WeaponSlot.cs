using UnityEngine;
using System.Collections;

public class WeaponSlot : MonoBehaviour {

    public GameObject defaultWeaponPrefab;

    private GameObject currentWeapon;

    void Start()
    {
        currentWeapon = null;

        SetWeapon(defaultWeaponPrefab);
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

    void Update()
    {
    }
}
