using UnityEngine;
using System.Collections;

public class AutoFire : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float frequency = 10;
    public float coneAngle = 1.5f;
    public bool firing = false;
    public float damagePerSecond = 20.0f;
    public float forcePerSecond = 20.0f;
    public float hitSoundVolume = 0.5f;
    public int bulletsLeft = 100;

    public GameObject muzzleFlashFront;
    public float muzzleFlashTime = 0.3f;

    private float lastFireTime = -1;
    private PerFrameRaycast raycast;

    private AmmoQuiver quiver;

	// Use this for initialization
	void Start () {
	
        //quiver = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent(AmmoQuiver);
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

        if (firing && Time.time > lastFireTime + 1 / frequency && quiver.GetCurrentWeaponAmmoCount() > 0)
        {
            if (audio)
                audio.Play();

            muzzleFlashFront.SetActive(true);

            // Spawn visual bullet
            var coneRandomRotation = Quaternion.Euler(Random.Range(-coneAngle, coneAngle), Random.Range(-coneAngle, coneAngle), 0);
            GameObject go = Spawner.Spawn(bulletPrefab, spawnPoint.position, spawnPoint.rotation * coneRandomRotation) as GameObject;
            SimpleBullet bullet = go.GetComponent<SimpleBullet>();

            lastFireTime = Time.time;

			quiver.ShootCurrentWeapon();

            // Find the object hit by the raycast
            RaycastHit hitInfo = raycast.GetHitInfo();
            if (hitInfo.transform)
            {
                // Get the health component of the target if any
                Health targetHealth = hitInfo.transform.GetComponent<Health>();
                if (targetHealth)
                {
                    // Apply damage
                    targetHealth.OnDamage(damagePerSecond / frequency, -spawnPoint.forward);
                }

                // Get the rigidbody if any
                if (hitInfo.rigidbody)
                {
                    // Apply force to the target object at the position of the hit point
                    Vector3 force = transform.forward * (forcePerSecond / frequency);
                    hitInfo.rigidbody.AddForceAtPosition(force, hitInfo.point, ForceMode.Impulse);
                }

                bullet.dist = hitInfo.distance;
            }
            else
            {
                bullet.dist = 1000;
            }
                Debug.Log("bullet distance: " + bullet.dist);
        }
        else
        {
            muzzleFlashFront.SetActive(false);
        }
    }

    public void OnStartFire()
    {
        if (Time.timeScale == 0)
            return;

        Debug.Log("wat");

        if (quiver.GetCurrentWeaponAmmoCount() > 0)
        {
            firing = true;
            muzzleFlashFront.SetActive(true);
        }
    }

    public void OnStopFire()
    {
        firing = false;

        muzzleFlashFront.SetActive(false);
    }
    
}


