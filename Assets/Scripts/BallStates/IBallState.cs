using UnityEngine;

public interface IBallState {
    void HandleCollisionEnter(Ball ball, Collision collision);
    
    string GetStateName();
}