﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
	
	private Vector3 direction;
	public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;

	private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating("AnimateSprite", 0.15f, 0.15f);
    }

	private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
		{
            direction = Vector3.up * strength;
   			SoundManager.PlaySound("fly");
        }

		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				 direction = Vector3.up * strength;
      			 SoundManager.PlaySound("fly");
			}
		}

        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Tilt the bird based on the direction
        //Vector3 rotation = transform.eulerAngles;
        //rotation.z = direction.y * tilt;
        //transform.eulerAngles = rotation;
	}

	private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0) {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.CompareTag("Scoring")) {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}
