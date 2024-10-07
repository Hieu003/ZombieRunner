using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int CurrentWeapon = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = CurrentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != CurrentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(CurrentWeapon >= transform.childCount - 1)
            {
                CurrentWeapon = 0;
            }
            else
            {
                CurrentWeapon--;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (CurrentWeapon <= 0)
            {
                CurrentWeapon = transform.childCount - 1;
            }
            else
            {
                CurrentWeapon++;
            }
        }
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            CurrentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeapon = 1;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if(weaponIndex == CurrentWeapon) {
            weapon.gameObject.SetActive(true);
            }
            else
            {
            weapon.gameObject.SetActive(false);

            }
            weaponIndex++;
        }

    }

   
}
