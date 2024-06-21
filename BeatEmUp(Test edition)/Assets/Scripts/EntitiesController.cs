using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntitiesController : MonoBehaviour
{
    [SerializeField]
    public float life;

    [SerializeField]
    private Transform punchPos, kickPos;

    private bool canAttack = true;

    public void Move(Rigidbody2D rig, float dirX, float dirY, float spd)
    {
        rig.velocity = new Vector2(dirX, dirY) * spd;

        FlipCharacter(dirX);
    }

    private void FlipCharacter(float dirX)
    {
        if (dirX > 0) dirX = 1;
        else if (dirX < 0) dirX = -1;

        if (dirX != 0)
        {
            transform.localScale = new Vector3(dirX, transform.localScale.y, transform.localScale.z);
        }
    }

    public IEnumerator Attacking(Attack attack)
    {
        if (canAttack)
        {
            Collider2D[] attackCol = null;

            switch (attack.TypeOfAttack)
            {
                case "Punch":
                    attackCol = Physics2D.OverlapBoxAll(punchPos.position, new Vector2(1, 0.5f), 0);
                    break;
                case "Kick":
                    attackCol = Physics2D.OverlapBoxAll(kickPos.position, new Vector2(0.75f, 0.75f), 0);
                    break;
            }

            foreach (Collider2D col in attackCol)
            {
                if (col.gameObject.layer != gameObject.layer)
                    col.gameObject.GetComponent<EntitiesController>().TakingDamage(attack.DamageOfAttack);
            }

            canAttack = false;

            yield return new WaitForSeconds(attack.WaitTimeOfAttack);

            canAttack = true;
        }
    }

    public void TakingDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
            Death();
    }

    void Death()
    {
        switch (gameObject.layer)
        {
            case 6: //Layer of Player
                int curScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(curScene);
                break;
            case 7: //Layer of Enemies
                Destroy(gameObject);
                break;
        }
    }
}