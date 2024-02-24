using UnityEngine;

public abstract class SpecialPowerState : IBallState {
    protected string stateName;
    protected float timeToDestroyPlatform = 1.5f;
    protected float forceToDestroyPlatform = 100f;

    public virtual void HandleCollisionEnter(Ball ball, Collision collision) {

        PlatformDestruction platformDestruction = collision.gameObject.GetComponentInParent<PlatformDestruction>();
        platformDestruction?.SetPlatformMaterial(BallVisual.Instance.GetBallNormalMaterial());
        platformDestruction?.DestroyPlatform(forceToDestroyPlatform, timeToDestroyPlatform);
        
        ball.SetState(NormalState.Instance);
        ball.SetVelocity(Vector3.zero);
        ball.AddBounceForce();
    }

    public string GetStateName() {
        return stateName;
    }
}