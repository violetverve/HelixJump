using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallVisual : MonoBehaviour {
    [SerializeField] private Material materialNormalSphere;
    [SerializeField] private Material materialSuperSphere;
    [SerializeField] private Material materialNormalTrail;
    [SerializeField] private Material materialSuperTrail;

    private MeshRenderer meshRenderer;
    private TrailRenderer trailRenderer;
    

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();

        meshRenderer.material = materialNormalSphere;
        trailRenderer.material = materialNormalTrail;
    }

    
    private void Start() {
        Ball.Instance.OnBallStateChanged += Ball_OnBallStateChanged;
    }

    private void Ball_OnBallStateChanged(object sender, System.EventArgs e) {
        Ball.State state = Ball.Instance.GetState();
        if (state ==  Ball.State.Normal) {
            meshRenderer.material = materialNormalSphere;
            trailRenderer.material = materialNormalTrail;
        } else if (state ==  Ball.State.Super) {
            meshRenderer.material = materialSuperSphere;
            trailRenderer.material = materialSuperTrail;
        }
    }

}
