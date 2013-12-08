using UnityEngine;
using System.Collections;

public class missilefire : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float frequency = 10;
    public float coneAngle = 1.5f;
    public bool firing = false;
    public float damagePerSecond = 50.0f;
    public float forcePerSecond = 20.0f;
    public float hitSoundVolume = 0.5f;

    public GameObject muzzleFlashFront;
    public float muzzleFlashTime = 0.3f;

    private float lastFireTime = -1;
    private PerFrameRaycast raycast;

    private AmmoQuiver quiver;

	// Use this for initialization
	void Start () {
	
        quiver = GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoQuiver>();
	}

    void Awake ()
    {
        muzzleFlashFront.SetActive (false);

        raycast = GetComponent<PerFrameRaycast>();
        if (spawnPoint == null)
            spawnPoint = transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > lastFireTime + muzzleFlashTime)
        {
            muzzleFlashFront.SetActive(false);
        }

        if (firing)
        {
            if (Time.time > lastFireTime + 1 / frequency)
            {
                if (quiver.GetCurrentWeaponAmmoCount() > 0)
                {
                    if (audio)
                        audio.Play();

                    muzzleFlashFront.SetActive(true);

                    var coneRandomRotation = Quaternion.Euler(Random.Range(-coneAngle, coneAngle), Random.Range(-coneAngle, coneAngle), 0);
                    GameObject go = Spawner.Spawn(bulletPrefab, spawnPoint.position, spawnPoint.rotation * coneRandomRotation) as GameObject;
                    SimpleBullet bullet = go.GetComponent<SimpleBullet>();

                    lastFireTime = Time.time;

					quiver.ShootCurrentWeapon(); ;
                }

            }
        }
    }

    public void OnStartFire()
    {
        if (Time.timeScale == 0)
            return;

        firing = true;

        muzzleFlashFront.SetActive(true);
    }

    public void OnStopFire()
    {
        firing = false;

        muzzleFlashFront.SetActive(false);
    }
    
}


