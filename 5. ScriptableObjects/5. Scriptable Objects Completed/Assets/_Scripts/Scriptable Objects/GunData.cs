using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunData : ScriptableObject {

	public int damagePerShot = 20; // The damage inflicted by each bullet.
	public float timeBetweenBullets = 0.15f; // The time between each shot.
	public float range = 100f; // The distance the gun can fire.

	public Color color;
	public ParticleSystem particles;
	public AmmoType ammoType;
}