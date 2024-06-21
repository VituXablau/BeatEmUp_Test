using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour
{
    private EnemiesAIController aiControll;
    private Rigidbody2D rig;

    [SerializeField]
    private float spd;

    [SerializeField]
    private Attack[] attacks;

    void Start()
    {
        aiControll = GetComponent<EnemiesAIController>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(aiControll.CanAttack())
            aiControll.Attack(attacks);
    }

    void FixedUpdate()
    {
        aiControll.Move(rig, aiControll.DirToPlayer().x, aiControll.DirToPlayer().y, spd);
    }
}
