using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour 
{
	
	public GameObject[] pickups;
	public int TimeMultiplier;
	public int MaxWaitWithoutMultiplier;
	public bool running;
	public bool active;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	//	SpawnPickup();
	}
	
	//void SpawnPickup()
	//{
	//	Debug.Log ("lol");hmm
	//	yield return new WaitForSeconds(3f);
	//	
	//}
}
