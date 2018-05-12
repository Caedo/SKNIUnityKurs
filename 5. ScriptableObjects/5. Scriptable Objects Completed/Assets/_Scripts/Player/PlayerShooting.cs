using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace Completed {

    public class PlayerShooting : MonoBehaviour {

        public List<GunData> m_GunData;

        float timer; // A timer to determine when to fire.
        Ray shootRay = new Ray(); // A ray from the gun end forwards.
        RaycastHit shootHit; // A raycast hit to get information about what was hit.
        int shootableMask; // A layer mask so the raycast only hits things on the shootable layer.

        LineRenderer gunLine; // Reference to the line renderer.
        AudioSource gunAudio; // Reference to the audio source.
        Light gunLight; // Reference to the light component.
        public Light faceLight; // Duh
        public float effectsDisplayTime = 0.2f; // time effects will display for.

        GunData currentGunData;
        ParticleSystem gunParticles;

        void Awake() {
            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask("Shootable");

            // Set up the references.
            gunLine = GetComponent<LineRenderer>();
            gunAudio = GetComponent<AudioSource>();
            gunLight = GetComponent<Light>();
            faceLight = GetComponentInChildren<Light>();

            SetCurrentGunData(0);
        }

        void Update() {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the Fire1 button is being press and it's time to fire...
            if (Input.GetButton("Fire1") && timer >= currentGunData.timeBetweenBullets && Time.timeScale != 0) {
                // ... shoot the gun.
                Shoot();
            }

            // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
            if (timer >= effectsDisplayTime) {
                // ... disable the effects.
                DisableEffects();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                SetCurrentGunData(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                SetCurrentGunData(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                SetCurrentGunData(2);
            }
        }

        void SetCurrentGunData(int index) {
            currentGunData = m_GunData[index];

            gunLine.endColor = currentGunData.color;
            gunLine.startColor = currentGunData.color;

            if (gunParticles != null) {
                Destroy(gunParticles.gameObject);
                gunParticles = null;
            }
            if (currentGunData.particles != null) {
                gunParticles = Instantiate(currentGunData.particles, transform);
                gunParticles.transform.position = Vector3.zero;
            }

            gunLight.color = currentGunData.color;
        }

        public void DisableEffects() {
            // Disable the line renderer and the light.
            gunLine.enabled = false;
            faceLight.enabled = false;
            gunLight.enabled = false;
        }

        void Shoot() {
            // Reset the timer.
            timer = 0f;

            //Rotate gun to target
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.up * transform.position.y);
            float rayLength;
            if (plane.Raycast(ray, out rayLength)) {
                Vector3 point = ray.GetPoint(rayLength);
                transform.LookAt(point);
            }

            // Play the gun shot audioclip.
            gunAudio.Play();

            // Enable the lights.
            gunLight.enabled = true;
            faceLight.enabled = true;

            //fire Particles
            gunParticles?.Stop();
            gunParticles?.Play();

            // Enable the line renderer and set it's first position to be the end of the gun.
            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            // Perform the raycast against gameobjects on the shootable layer and if it hits something...
            if (Physics.Raycast(shootRay, out shootHit, currentGunData.range, shootableMask)) {
                // Try and find an EnemyHealth script on the gameobject hit.
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                // If the EnemyHealth component exist...
                if (enemyHealth != null) {
                    // ... the enemy should take damage.
                    enemyHealth.TakeDamage(new DamageInfo {
                        amount = currentGunData.damagePerShot,
                            point = shootHit.point,
                            ammoType = currentGunData.ammoType
                    });
                }

                // Set the second position of the line renderer to the point the raycast hit.
                gunLine.SetPosition(1, shootHit.point);
            }
            // If the raycast didn't hit anything on the shootable layer...
            else {
                // ... set the second position of the line renderer to the fullest extent of the gun's range.
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * currentGunData.range);
            }
        }
    }
}