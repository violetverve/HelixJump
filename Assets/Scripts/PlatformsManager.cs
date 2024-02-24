using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformsManager : MonoBehaviour {
    public static PlatformsManager Instance { get; private set; }
    public event EventHandler OnPlatformIndexChanged;
    private int currentPlatformIndex = 0;

    private void Awake() {
        Instance = this;
    }

    public void IncrementPlatformIndex() {
        currentPlatformIndex++;

        OnPlatformIndexChanged?.Invoke(this, EventArgs.Empty);  
    }

    public int GetCurrentPlatformIndex() {
        return currentPlatformIndex;
    }

    public Vector3 GetCurrentPlatformPosition() {
        return new Vector3(0, -currentPlatformIndex * HelixManager.Instance.GetLevelDistance(), 0);
    }

    public float GetYPosPlatformPosition(int index) {
        return -index * HelixManager.Instance.GetLevelDistance();
    }

}