using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
	public GameObject[] Weapons;

	public GameObject ActiveWeapon;


	// Update is called once aper frame
	void LateUpdate()
	{
		WeaponSwitchMode();
	}

	public int WeaponNumber;
	void WeaponSwitchMode()
	{
		/*
		 * Automatic adding scroll
		 */

		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			WeaponNumber = (WeaponNumber + 1);
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			WeaponNumber = (WeaponNumber - 1);
		}

		/*
		 * Adding alphanumerics access to weapons
		 */

		if (Input.GetKeyDown(KeyCode.Alpha1)) WeaponNumber = 0;
		if (Input.GetKeyDown(KeyCode.Alpha2)) WeaponNumber = 1;
		if (Input.GetKeyDown(KeyCode.Alpha3)) WeaponNumber = 2;

		if (WeaponNumber < 0) WeaponNumber = Weapons.Length-1;
		if (WeaponNumber >= Weapons.Length) WeaponNumber = 0;

		/*
		 * Automatically disables all other weapons instead of destroying them
		 */

		foreach (GameObject Item in Weapons)
		{
			Item.SetActive(false);
		}
		ActiveWeapon = Weapons[WeaponNumber];
		ActiveWeapon.SetActive(true);
	}
}
