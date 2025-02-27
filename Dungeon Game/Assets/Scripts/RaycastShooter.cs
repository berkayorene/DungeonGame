using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooter : MonoBehaviour
{

    public Camera fpsCam;
    public float range = 100f;
    public LayerMask targetLayer;

    public ParticleSystem muzzleFlash;
    public ParticleSystem wallHitEffect;
    public ParticleSystem enemyHitEffect;
    public Transform gunTransform;

    private void Update()
    {
        Vector3 rayOrigin = fpsCam.transform.position;
        Vector3 rayDirection = fpsCam.transform.forward;
        RaycastHit hit;

        if (Input.GetButtonDown("Fire1"))
        {
            //muzzleFlash.Play();

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, range, targetLayer))
            {
                Debug.DrawRay(rayOrigin, rayDirection * hit.distance, Color.red, 0.1f);
                Debug.Log("Target hit: " + hit.collider.name);

                if (hit.collider.CompareTag("Wall1"))
                {
                    Instantiate(wallHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                }
                else if (hit.collider.CompareTag("Enemy1"))
                {
                    Instantiate(enemyHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }

    }
}
