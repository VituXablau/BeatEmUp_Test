using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private EntitiesController controller;

    private float dirX, dirY;

    [SerializeField]
    private float spd;

    private Attack weakPunch, weakKick;

    void Start()
    {
        controller = GetComponent<EntitiesController>();

        weakPunch = new Attack("Punch", 3, 5);
        weakKick = new Attack("Kick", 5, 7);
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.J))
            StartCoroutine(controller.Attacking(weakPunch));
        if (Input.GetKeyDown(KeyCode.K))
            StartCoroutine(controller.Attacking(weakKick));
    }

    void FixedUpdate()
    {
        controller.Move(dirX, dirY, spd);
    }
}
