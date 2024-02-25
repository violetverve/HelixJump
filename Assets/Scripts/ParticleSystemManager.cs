using UnityEngine;

public class ParticleSystemManager : MonoBehaviour {
    public static ParticleSystemManager Instance { get; private set; }

    [SerializeField] private ParticleSystem collisionParticleSystem;

    private void Awake() {
        Instance = this;
    }

    public void PlayCollisionParticleSystem(Vector3 position) {
        collisionParticleSystem.transform.position = position;
        collisionParticleSystem.Play();
    }
}