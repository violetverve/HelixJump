using UnityEngine;

public class ComboState : IBallState {

    private static ComboState instance;
    private const string stateName = "Combo";
    public static ComboState Instance => instance ??= new ComboState();
    private ComboState() {}
    
    public void HandleCollisionEnter(Ball ball, Collision collision) {
        
        PlatformDestruction platformDestruction = collision.gameObject.GetComponentInParent<PlatformDestruction>();
            
        platformDestruction?.DestroyPlatform();

        ball.SetState(NormalState.Instance);
        
        ball.SetVelocity(Vector3.zero);
    }

    public string GetStateName() {
        return stateName;
    }
}