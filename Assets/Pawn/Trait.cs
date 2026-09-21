using UnityEngine;


[System.Serializable]
public struct StateModifier
{
    public StateType state;
    public float multiplier;
}

/// <summary>
/// Trait that Pawn can possess.
/// Adjustable in Unity Editor.
/// Choose what and how much trait effect to state.
/// </summary>
[CreateAssetMenu(fileName = "Trait", menuName = "Scriptable Objects/Trait")]
public class Trait : ScriptableObject
{
    public string traitName;
    public StateModifier[] modifier;

    public float GetMultiplier(StateType key)
    {
        foreach (var mod in modifier)
            if(mod.state == key) return mod.multiplier;
        
        return 1f;
    }
}
