using UnityEngine;

[CreateAssetMenu(fileName = "FieldSettingData", menuName = "Scriptable Objects/FieldSettingData")]
public class FieldSettingData : ScriptableObject
{
    public string biomeName;

    public int defaultOcean;
    public int defaultDirt;
    public int defaultStone;

    public float waterThreshold;
    public float dirtThreshold;
    public float stoneThreshold;

    public float mountainThreshold; //for determining Roof

    //And more...
}
