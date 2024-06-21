using UnityEngine;

public class EnemiesAIController : EntitiesController
{
    [SerializeField]
    private LayerMask layerPlayer;

    [SerializeField]
    private float checkAreaSize;

    public Vector2 DirToPlayer()
    {
        Collider2D[] checkArea = Physics2D.OverlapCircleAll(transform.position, checkAreaSize / 2, layerPlayer);

        foreach (Collider2D col in checkArea)
        {
            if (col != null)
            {
                Vector2 myPos = transform.position;
                Vector2 targPos = col.transform.position;

                Vector2 dir = targPos - myPos;
                return dir = dir.normalized;
            }
        }
        return Vector2.zero;
    }

    public bool CanAttack()
    {
        if (Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0), 1.25f, layerPlayer))
        {
            return true;
        }
        return false;
    }

    public void Attack(Attack[] attacks)
    {
        int attackRandom = Random.Range(0, attacks.Length);

        StartCoroutine(Attacking(attacks[attackRandom]));
    }
}
