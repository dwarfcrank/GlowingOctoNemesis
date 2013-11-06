using UnityEngine;
using System.Collections;

public class GameEnv : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private int kills = 0;
    private int wave = 0;
    private int numEnemiesThisWave = 0;
    private int numCurrentEnemies = 0;

    public int GetKills()
    {
        return kills;
    }

    public int GetCurrentWave()
    {
        return wave;
    }

	// Use this for initialization
	void Start () {
	}

    void SpawnRandom(Transform location)
    {
        var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        var enemy = Instantiate(prefab, location.position, location.rotation) as GameObject;
        var spawnCollider = location.gameObject.collider;
        var enemyCollider = enemy.collider;

        Physics.IgnoreCollision(spawnCollider, enemyCollider);
        enemy.BroadcastMessage("OnSpotted");

        enemy.SetActive(true);
        enemy.tag = "Enemy";

        var health = enemy.GetComponent<Health>();

        var origReceivers = health.dieSignals.receivers;
        var receivers = new ReceiverItem[origReceivers.Length];

        for (int i = 0; i < origReceivers.Length; i++)
        {
            receivers[i] = origReceivers[i];
        }

        receivers[receivers.Length - 1] = new ReceiverItem
        {
            action = "OnEnemyDeath",
            receiver = gameObject
        };

        health.dieSignals.receivers = receivers;

        numCurrentEnemies++;
    }

    IEnumerator SpawnWave()
    {
        wave++;

        for (int i = 0; i < wave; i++)
        {
            foreach (Transform t in spawnPoints)
            {
                SpawnRandom(t);
                numEnemiesThisWave++;
            }

            yield return new WaitForSeconds(5.0f);
        }
    }

    void OnEnemyDeath()
    {
        numCurrentEnemies--;
    }

	// Update is called once per frame
	void Update () 
    {
        if (numCurrentEnemies == 0)
        {
            StartCoroutine("SpawnWave");
        }
	}
}
