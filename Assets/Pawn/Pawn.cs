using Mono.Cecil;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    HealthPoint,
    ManaPoint,

    HungerRate,
    HumanityRate,
    MoodRate,
    
    DefenseRate,
    MoveSpeedRate,
    AttackSpeedRate,
    JobSpeedRate,
}

public class Pawn
{
    public Vector2 position;

    public float healthPoint;
    public float manaPoint;

    public float hunger;
    public float mood;

    //Basic Rate to apply at State
    protected Dictionary<StateType, float> baseState = new();
    //Modified Rate gonna apply at State
    protected Dictionary<StateType, float> modifiedState = new();

    public float GetState(StateType type) => modifiedState[type];



    /// <summary>
    /// Base function for updating Pawn.
    /// </summary>
    public virtual void Tick(float deltaTime) { }
}
