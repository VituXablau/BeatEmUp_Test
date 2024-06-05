using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    private string _typeOfAttack;
    private float _waitTimeOfAttack, _damageOfAttack;

    public Attack(string typeOfAttack, float waitTimeOfAttack, float damageOfAttack)
    {
        _typeOfAttack = typeOfAttack;
        _waitTimeOfAttack = waitTimeOfAttack;
        _damageOfAttack = damageOfAttack;
    }

    public string TypeOfAttack
    {
        get { return _typeOfAttack; }
        set { _typeOfAttack = value; }
    }

    public float WaitTimeOfAttack
    {
        get { return _waitTimeOfAttack; }
        set { _waitTimeOfAttack = value; }
    }

    public float DamageOfAttack
    {
        get { return _damageOfAttack; }
        set { _damageOfAttack = value; }
    }
}
