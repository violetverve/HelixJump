using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallVisual : MonoBehaviour {
    private static string SQUASH_TRIGGER = "Squashed";
    [SerializeField] private Material materialNormalSphere;
    [SerializeField] private Material materialSuperSphere;
    [SerializeField] private Material materialNormalTrail;
    [SerializeField] private Material materialSuperTrail;
    [SerializeField] private ParticleSystem hitPlatformParticleSystem;

    private Animator animator;

    private MeshRenderer meshRenderer;
    private TrailRenderer trailRenderer;
    

    private void Awake() {
        animator = GetComponent<Animator>();

        meshRenderer = GetComponent<MeshRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();

        meshRenderer.material = materialNormalSphere;
        trailRenderer.material = materialNormalTrail;
    }
    
    private void Start() {
        Ball.Instance.OnBallStateChanged += Ball_OnBallStateChanged;
        Ball.Instance.OnBallHitPlatform += Ball_OnBallHitPlatform;
    }
    
    private void Ball_OnBallHitPlatform(object sender, Ball.BallHitPlatformEventArgs e) {
        animator.SetTrigger(SQUASH_TRIGGER);

        hitPlatformParticleSystem.transform.position = e.position;
        hitPlatformParticleSystem.Play();
    }

    private void Ball_OnBallStateChanged(object sender, System.EventArgs e) {
        Ball.State state = Ball.Instance.GetState();
        if (state ==  Ball.State.Normal) {
            meshRenderer.material = materialNormalSphere;
            trailRenderer.material = materialNormalTrail;
        } else if (state ==  Ball.State.Super) {
            meshRenderer.material = materialSuperSphere;
            trailRenderer.material = materialSuperTrail;
        }
    }

}
