using UnityEngine;

[CreateAssetMenu(fileName = "ResidentSettingData", menuName = "Scriptable Objects/ResidentSettingData")]
public class ResidentSettingData : ScriptableObject
{
    public float MaxHealthPoint = 100.0f;
    public float maxManaPoint = 100.0f;

    public float maxHunger = 100.0f;
    public float maxHumanity = 100.0f;
    public float maxMood = 100.0f;

    //Adjust max value
    public float baseHealthPointRate = 1f;
    public float baseManaPointRate = 1f;

    //Adjust reduction or increase for tick
    public float baseHungerRate = 1f;
    public float baseHumanityRate = 1f;
    public float baseMoodRate = 1f;

    public float baseDefenseRate = 1f;
    public float baseMoveSpeedRate = 1f;
    public float baseAttackSpeedRate = 1f;
    public float baseJobSpeedRate = 1f;
}
