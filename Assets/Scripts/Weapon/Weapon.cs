using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FirePointCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBeteweenShots;
    [SerializeField] TextMeshProUGUI ammoText;

    [Header("Joystick")]
    [SerializeField] FixedJoystick joystick;
    [SerializeField] Button shootButton; // Reference to the shooting button

    bool canShoot = true;


    private void Start()
    {
        // Add listener to the button
        if (shootButton != null)
        {
            shootButton.onClick.AddListener(OnShootButtonPressed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();

        // Check if joystick is being used
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            return; // Do not shoot if joystick is in use
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void OnShootButtonPressed()
    {
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    private void OnEnable()
    {
        canShoot = true;
    }

    IEnumerator Shoot()
    {
        
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0) 
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBeteweenShots);
        canShoot = true;
       
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
      if(  Physics.Raycast(FirePointCamera.transform.position, FirePointCamera.transform.forward, out hit, range))
        {
            Debug.Log("i hit  this thing : " + hit.transform.name);
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
       
    }

    private void CreateHitImpact(RaycastHit hit)
    {
       GameObject impact =  Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
