using UnityEngine;

namespace Completed {
    public class EnemyHealth : LivingEntity {
        public float sinkSpeed = 2.5f; // The speed at which the enemy sinks through the floor when dead.
        public int scoreValue = 10; // The amount added to the player's score when the enemy dies.

        public AmmoType m_WeakAgainst;

        ParticleSystem hitParticles; // Reference to the particle system that plays when the enemy is damaged.
        CapsuleCollider capsuleCollider; // Reference to the capsule collider.
        bool isSinking; // Whether the enemy has started sinking through the floor.

        public static event System.Action<EnemyHealth> OnEnemyDeath;

        protected override void Awake() {
            base.Awake();

            hitParticles = GetComponentInChildren<ParticleSystem>();
            capsuleCollider = GetComponent<CapsuleCollider>();
        }

        void Update() {
            // If the enemy should be sinking...
            if (isSinking) {
                // ... move the enemy down by the sinkSpeed per second.
                transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            }
        }

        public override void TakeDamage(DamageInfo info) {

            hitParticles.transform.position = info.point;

            if(m_WeakAgainst != null && info.ammoType == m_WeakAgainst){
                info.amount *= 2;
                Debug.Log(info.amount);
            }

            // And play the particles.
            hitParticles.Play();

            base.TakeDamage(info);
        }

        protected override void Death() {
            base.Death();

            // Turn the collider into a trigger so shots can pass through it.
            capsuleCollider.isTrigger = true;

            // Tell the animator that the enemy is dead.
            m_Anim.SetTrigger("Dead");
        }

        public void StartSinking() {
            // Find and disable the Nav Mesh Agent.
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

            // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
            GetComponent<Rigidbody>().isKinematic = true;

            if(OnEnemyDeath != null) {
                OnEnemyDeath(this);
            }

            // The enemy should no sink.
            isSinking = true;

            // After 2 seconds destory the enemy.
            Destroy(gameObject, 2f);
        }
    }
}