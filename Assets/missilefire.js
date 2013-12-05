#pragma strict

@script RequireComponent (PerFrameRaycast)

var bulletPrefab : GameObject;
var spawnPoint : Transform;
var frequency : float = 10;
var coneAngle : float = 1.5;
var firing : boolean = false;
var damagePerSecond : float = 20.0;
var forcePerSecond : float = 20.0;
var hitSoundVolume : float = 0.5;
var bulletsLeft = 100;

var muzzleFlashFront : GameObject;
var muzzleFlashTime : float = 0.3;

private var lastFireTime : float = -1;
private var raycast : PerFrameRaycast;


function Start()
{
    //quiver = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent("AmmoQuiver");
}
function Awake () {
    muzzleFlashFront.SetActive (false);

    raycast = GetComponent.<PerFrameRaycast> ();
    if (spawnPoint == null)
        spawnPoint = transform;
}



function Update () {
    if (Time.time > lastFireTime + muzzleFlashTime)
    {
        muzzleFlashFront.SetActive(false);
    }

    if (firing) {

        if (Time.time > lastFireTime + 1 / frequency)
        {  
            //if(quiver.bulletCount > 0)
            //{
                if (audio)
                    audio.Play ();
            
                muzzleFlashFront.SetActive(true);

                // Spawn visual bullet
                var coneRandomRotation = Quaternion.Euler (Random.Range (-coneAngle, coneAngle), Random.Range (-coneAngle, coneAngle), 0);
                var go : GameObject = Spawner.Spawn (bulletPrefab, spawnPoint.position, spawnPoint.rotation * coneRandomRotation) as GameObject;
                var bullet : SimpleBullet = go.GetComponent.<SimpleBullet> ();

                lastFireTime = Time.time;

                //quiver.bulletCount--;
            //}
        }
    }
}

function OnStartFire () {
    if (Time.timeScale == 0)
        return;

    firing = true;

    muzzleFlashFront.SetActive (true);

//	if (audio)
//		audio.Play ();
}

function OnStopFire () {
    firing = false;

    muzzleFlashFront.SetActive (false);

    //    if (audio)
    //        audio.Stop ();
}