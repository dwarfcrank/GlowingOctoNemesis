using UnityEngine;
using System.Collections;

public class SpawnPickup : MonoBehaviour {
	
	public GameObject[] pickups;
	public int numberOfPickups;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnEnemyDeath(){
		//if(Random.Range (1,100)<30)
		//{
			transform.DetachChildren();
			int pickup = Random.Range(0,numberOfPickups);
			Vector3 pos = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
			Quaternion rot = new Quaternion(0,90,90,0);
			Instantiate(pickups[pickup], pos, rot);
		//}
	}
}
