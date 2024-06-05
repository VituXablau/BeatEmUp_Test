using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesController : MonoBehaviour
{
    private Rigidbody2D rig;

    private bool canAttack = true;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();   
    }
    
    public void Move(float dirX, float dirY, float spd)
    {
        rig.velocity = new Vector2(dirX, dirY) * spd;
    }

    public IEnumerator Attacking(Attack attack)
    {
        if (canAttack)
        {
            switch (attack.TypeOfAttack)
            {
                case "Punch":
                    Debug.Log(attack.DamageOfAttack);
                    break;
                case "Kick":
                    Debug.Log(attack.DamageOfAttack);
                    break;
            }

            canAttack = false;

            yield return new WaitForSeconds(attack.WaitTimeOfAttack);

            canAttack = true;
        }
    }
}
