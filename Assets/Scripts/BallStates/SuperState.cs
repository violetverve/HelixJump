using UnityEngine;

public class SuperState : SpecialPowerState {
    private static SuperState instance;
    private int platformsHitWithSuper = 0;
    private readonly int platformsHitWithSuperToNormal = 4;

    public static SuperState Instance => instance ??= new SuperState();

    private SuperState() {
        stateName = "Super";
    }

    public override void HandleCollisionEnter(Ball ball, Collision collision) {
        base.HandleCollisionEnter(ball, collision);
        ResetPlatformsHitWithSuper();
    }

    public void IncrementPlatformsHitWithSuper() {
        platformsHitWithSuper++;
    }

    public void ResetPlatformsHitWithSuper() {
        platformsHitWithSuper = 0;
    }

    public void ResetSuperState() {
        ResetPlatformsHitWithSuper();
    }

    public bool IsDestroying() {
        return platformsHitWithSuper < platformsHitWithSuperToNormal;
    }
}
