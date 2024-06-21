using UnityEngine;

public class PlayerController : EntitiesController
{
    private Rigidbody2D rig;

    private float dirX, dirY;

    [SerializeField]
    private float spd;

    [SerializeField]
    private Attack[] attacks;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log("Vida do " + gameObject.name + "= " + life);

        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.J))
            StartCoroutine(Attacking(attacks[0]));
        if (Input.GetKeyDown(KeyCode.K))
            StartCoroutine(Attacking(attacks[1]));
        if (Input.GetKeyDown(KeyCode.N))
            StartCoroutine(Attacking(attacks[2]));
        if (Input.GetKeyDown(KeyCode.M))
            StartCoroutine(Attacking(attacks[3]));
    }

    void FixedUpdate()
    {
        Move(rig, dirX, dirY, spd);
    }
}
