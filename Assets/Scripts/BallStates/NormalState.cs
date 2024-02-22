using UnityEngine;

public class NormalState : IBallState {

    private static NormalState instance;
    private const string stateName = "Normal";
    public static NormalState Instance => instance ??= new NormalState();

    private NormalState() {}

    public void HandleCollisionEnter(Ball ball, Collision collision) {
        ball.SetVelocity(Vector3.zero);
        ball.AddBounceForce();
    }

    public string GetStateName() {
        return stateName;
    }

}
