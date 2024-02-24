using UnityEngine;

public class NormalState : IBallState {

    private static NormalState instance;
    private const string stateName = "Normal";
    public static NormalState Instance => instance ??= new NormalState();

    private int platformsPassedWithoutCollision = 0;
    private int platformsPassedWithoutCollisionToCombo = 2;

    private NormalState() {}

    public void HandleCollisionEnter(Ball ball, Collision collision) {
        ball.SetVelocity(Vector3.zero);
        ball.AddBounceForce();

        ResetPlatformsPassedWithoutCollision();
    }

    public string GetStateName() {
        return stateName;
    }

    public void IncrementPlatformsPassedWithoutCollision() {
        if (ShouldTransitionToComboState()) {
            Ball.Instance.SetState(ComboState.Instance);
            ResetPlatformsPassedWithoutCollision();
        } else {
            platformsPassedWithoutCollision++;
        }
    }

    private bool ShouldTransitionToComboState() {
        return platformsPassedWithoutCollision == platformsPassedWithoutCollisionToCombo;
    }

    public void ResetPlatformsPassedWithoutCollision() {
        platformsPassedWithoutCollision = 0;
    }

    public void ResetNormalState() {
        ResetPlatformsPassedWithoutCollision();
    }

}
