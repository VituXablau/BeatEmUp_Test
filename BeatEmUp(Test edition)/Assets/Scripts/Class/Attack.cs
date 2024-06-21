using System;
using UnityEngine;

[System.Serializable]
public class Attack
{
    [SerializeField]
    private string _typeOfAttack;
    [SerializeField]
    private float _waitTimeOfAttack, _damageOfAttack;

    public string TypeOfAttack
    {
        get { return _typeOfAttack; }
    }

    public float WaitTimeOfAttack
    {
        get { return _waitTimeOfAttack; }
    }

    public float DamageOfAttack
    {
        get { return _damageOfAttack; }
    }
}
