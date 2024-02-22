using UnityEngine;

public class SuperState: IBallState {
    private static SuperState instance;
    private string stateName = "Super";
    private int platformsHitWithSuper = 0;
    private readonly int platformsHitWithSuperToNormal = 4;

    public static SuperState Instance => instance ??= new SuperState();

    private SuperState() { }

    public void HandleCollisionEnter(Ball ball, Collision collision)
    {
        if (platformsHitWithSuper == platformsHitWithSuperToNormal) {
                        
            ball.SetState(NormalState.Instance);

            platformsHitWithSuper = 0;
        }
    }

    public void IncrementPlatformsHitWithSuper() {
        platformsHitWithSuper++;
    }

    public string GetStateName() {
        return stateName;
    }
}
