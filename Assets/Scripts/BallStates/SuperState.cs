using UnityEngine;

public class SuperState: IBallState {
    private static SuperState instance;
    private string stateName = "Super";
    private int platformsHitWithSuper = 0;
    private readonly int platformsHitWithSuperToNormal = 4;

    public static SuperState Instance => instance ??= new SuperState();

    private SuperState() { }

    public void HandleCollisionEnter(Ball ball, Collision collision) {

    }

    public void IncrementPlatformsHitWithSuper() {
        platformsHitWithSuper++;

        if (platformsHitWithSuper == platformsHitWithSuperToNormal) {

            Ball.Instance.SetState(NormalState.Instance);

            platformsHitWithSuper = 0;
        }
    }

    public string GetStateName() {
        return stateName;
    }

    public void ResetPlatformsHitWithSuper() {
        platformsHitWithSuper = 0;
    }
    public void ResetSuperState() {
        ResetPlatformsHitWithSuper();
    }
}
