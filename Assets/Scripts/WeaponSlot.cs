using UnityEngine;
using System.Collections;

public class WeaponSlot : MonoBehaviour {

    public GameObject weaponPrefab;

    // Use this for initialization
    void Start () {
        var weapon = (GameObject)Instantiate(weaponPrefab, transform.position, transform.rotation);
        weapon.transform.parent = transform;

        var trigger = weapon.GetComponent<TriggerOnMouseOrJoystick>();
        var player = GameObject.FindGameObjectWithTag("Player");

        var mouseDownReceivers = new ReceiverItem[2];

        mouseDownReceivers[0] = new ReceiverItem();
        mouseDownReceivers[0].action = "OnStartFire";
        mouseDownReceivers[0].receiver = weapon;

        mouseDownReceivers[1] = new ReceiverItem();
        mouseDownReceivers[1].action = "OnStartFire";
        mouseDownReceivers[1].receiver = player;

        var mouseUpReceivers = new ReceiverItem[2];

        mouseUpReceivers[0] = new ReceiverItem();
        mouseUpReceivers[0].action = "OnStopFire";
        mouseUpReceivers[0].receiver = weapon;

        mouseUpReceivers[1] = new ReceiverItem();
        mouseUpReceivers[1].action = "OnStopFire";
        mouseUpReceivers[1].receiver = player;

        trigger.mouseDownSignals.receivers = mouseDownReceivers;
        trigger.mouseUpSignals.receivers = mouseUpReceivers;
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}
