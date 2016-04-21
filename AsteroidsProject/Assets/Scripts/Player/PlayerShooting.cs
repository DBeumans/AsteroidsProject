using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public Bullit projectile;
    public Transform muzzle;
    public float bullitSpeed = 20;

    private float fireRate = 0.1f;
    public float nextFire = 0.0f;
    void Update()
    {

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            Shoot();

        }

    }

    private void Shoot()
    {
        nextFire = Time.time + fireRate;
        Bullit newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Bullit;
        newProjectile.SetSpeed(bullitSpeed);
    }
}
