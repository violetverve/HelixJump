using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallVisual : MonoBehaviour {
    private static string SQUASH_TRIGGER = "Squashed";
    [SerializeField] private List<BallStateVisualSO> ballStateVisuals;

    [SerializeField] private ParticleSystem hitPlatformParticleSystem;

    private Animator animator;

    private MeshRenderer meshRenderer;
    private TrailRenderer trailRenderer;
    

    private void Awake() {
        animator = GetComponent<Animator>();

        meshRenderer = GetComponent<MeshRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    
    private void Start() {
        Ball.Instance.OnBallStateChanged += Ball_OnBallStateChanged;
        Ball.Instance.OnBallHitPlatform += Ball_OnBallHitPlatform;

        SetVisual(GetVisualByState(Ball.Instance.GetState()));
    }

    private void OnDestroy() {
        Ball.Instance.OnBallStateChanged -= Ball_OnBallStateChanged;
        Ball.Instance.OnBallHitPlatform -= Ball_OnBallHitPlatform;
    }
    
    private void Ball_OnBallHitPlatform(object sender, Ball.BallHitPlatformEventArgs e) {
        animator.SetTrigger(SQUASH_TRIGGER);

        hitPlatformParticleSystem.transform.position = e.position;
        hitPlatformParticleSystem.Play();
    }

    private void Ball_OnBallStateChanged(object sender, System.EventArgs e) {
        IBallState ballState = Ball.Instance.GetState();

        SetVisual(GetVisualByState(ballState));
    }

    private void SetVisual(BallStateVisualSO ballStateVisualSO) {
        meshRenderer.material = ballStateVisualSO.ballMaterial;
        trailRenderer.material = ballStateVisualSO.trailMaterial;
    }

    private BallStateVisualSO GetVisualByState(IBallState ballState) {
        foreach (BallStateVisualSO ballStateVisual in ballStateVisuals) {
            if (ballStateVisual.stateName == ballState.GetStateName()) {
                return ballStateVisual;
            }
        }

        return null;
    }

}
