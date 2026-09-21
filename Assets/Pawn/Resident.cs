using System.Collections.Generic;
using UnityEngine;


public class Resident : Pawn
{
    public float humanity;

    //ScriptableObject
    public List<Trait> traits;

    public Resident(Vector2 spawnPosition, ResidentSettingData setting, List<Trait> innateTraits) 
    {
        position = spawnPosition;

        healthPoint = setting.MaxHealthPoint;
        manaPoint = setting.maxManaPoint;

        hunger = setting.maxHunger;
        humanity = setting.maxHumanity / 2;
        mood = setting.maxMood;

        //initialize baseState
        InitBaseState(setting);

        //initialize Traits List
        traits = innateTraits;

        //Apply Traits
        ApplyTrait();
    }

    protected void InitBaseState(ResidentSettingData setting)
    {
        baseState[StateType.HealthPoint] = setting.baseHealthPointRate;
        baseState[StateType.ManaPoint] = setting.baseManaPointRate;
        baseState[StateType.HungerRate] = setting.baseHungerRate;
        baseState[StateType.HumanityRate] = setting.baseHumanityRate;
        baseState[StateType.MoodRate] = setting.baseMoodRate;
        baseState[StateType.DefenseRate] = setting.baseDefenseRate;
        baseState[StateType.MoveSpeedRate] = setting.baseMoveSpeedRate;
        baseState[StateType.AttackSpeedRate] = setting.baseAttackSpeedRate;
        baseState[StateType.JobSpeedRate] = setting.baseJobSpeedRate;
    }

    public void ApplyTrait()
    {
        foreach (var kv in baseState)
        {
            float baseRate = kv.Value;
            foreach (var trait in traits)
                baseRate *= trait.GetMultiplier(kv.Key);

            modifiedState[kv.Key] = baseRate;
        }
    }

    public void UpdateState(float deltaTime)
    {
        UpdateHunger(deltaTime);
    }


    public void UpdateHunger(float deltaTime)
    {
        hunger -= modifiedState[StateType.HungerRate] * 0.166f * deltaTime;
    }


    public override void Tick(float deltaTIme) 
    {
        base.Tick(deltaTIme);
    }

    public void Job() 
    {
        
    }
}
