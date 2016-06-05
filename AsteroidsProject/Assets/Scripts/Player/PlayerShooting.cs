using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class PlayerShooting : MonoBehaviour
{   
    public Bullit projectile;
    public Transform muzzle;
    public float bullitSpeed = 20;

	public AudioClip gunSound;
	private AudioSource source;

    private float fireRate = 0.1f;
    public float nextFire = 0.0f;

    CameraLock cameraLock;

	void Start()
	{
        cameraLock = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraLock>();
		source = GetComponent<AudioSource> ();
	}

    void Update()
    {

        if (Input.GetKey(KeyCode.Return) && Time.time > nextFire)
        {
            Shoot();
            cameraLock.ShakeCamera(0.1f, 0.2f);

        }

    }

    private void Shoot()
    {
        nextFire = Time.time + fireRate;
        Bullit newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Bullit;
        newProjectile.SetSpeed(bullitSpeed);

		source.PlayOneShot (gunSound, 1f);
    }
}
