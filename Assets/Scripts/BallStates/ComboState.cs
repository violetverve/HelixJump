using UnityEngine;

public class ComboState : SpecialPowerState {
    private static ComboState instance;

    public static ComboState Instance => instance ??= new ComboState();
    private ComboState() {
        stateName = "Combo";
    }
}