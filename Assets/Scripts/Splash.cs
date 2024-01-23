using UnityEngine;

public class Splash : MonoBehaviour {

    private CanvasGroup canvasGroup;
    private float timeToDestroy = 1f;
    private float timeToFade = 1f;

    private State state;

    private enum State {
        Idle,
        Fading,
        Destroyed
    }

    private void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();

        state = State.Idle;
    }

    private void Update() {

        switch (state) {
            case State.Idle:
                timeToDestroy -= Time.deltaTime;
                if (timeToDestroy <= 0f) state = State.Fading;
                break;
            case State.Fading:
                timeToFade -= Time.deltaTime;
                if (timeToFade <= 0f) state = State.Destroyed;
                canvasGroup.alpha -= Time.deltaTime;
                break;
            case State.Destroyed:
                Destroy(gameObject);
                break;
        }
        

    }
}
