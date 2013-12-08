using UnityEngine;
using System.Collections;

public class killbox : MonoBehaviour {

    public GameObject env;
    private GameEnv gameEnv;

	// Use this for initialization
	void Start () {
        gameEnv = env.GetComponent<GameEnv>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameEnv.OnEnemyKillboxDeath();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            other.SendMessage("OnSignal");
        }
    }
}
