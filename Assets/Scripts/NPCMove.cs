﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D NPCRigidbody;

    public bool isWalking, isTalking;

    public float walkTime = 1.5f;
    private float walkCounter;

    public float waitTime = 3.0f;
    private float waitCounter;

    private Vector2[] walkingDirection = { new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1) };
    private int currentDirection;
    public BoxCollider2D villagerZone;
    private DialogManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
        NPCRigidbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.dialogActive)
        {
            isTalking = false;
        }
        if (isTalking)
        {
            stopWalking();
            return;
        }
        if (isWalking)
        {
            if (villagerZone != null)
            {
                if (this.transform.position.x < villagerZone.bounds.min.x || this.transform.position.x > villagerZone.bounds.max.x || this.transform.position.y < villagerZone.bounds.min.y || this.transform.position.y > villagerZone.bounds.max.y)
                {
                    stopWalking();
                }
            }
            NPCRigidbody.velocity = walkingDirection[currentDirection] * speed;
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                stopWalking();
            }
        }
        else
        {
            NPCRigidbody.velocity = Vector2.zero;
            waitCounter -= Time.deltaTime;
            if (waitCounter < 0)
            {
                startWalking();
            }
        }
    }
    private void startWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4);
        walkCounter = walkTime;
    }
    private void stopWalking()
    {
        isWalking = false;
        waitCounter = waitTime;
        NPCRigidbody.velocity = Vector2.zero;
    }
}
