﻿using UnityEngine;
using System.Collections;

public class DirectionAnimation : MonoBehaviour
{
	int num;
	private Animator animator;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		
		if (vertical > 0)
		{
			animator.SetInteger("Direction", 2);
		}
		else if (vertical < 0)
		{
			animator.SetInteger("Direction", 0);
		}
		else if (horizontal > 0)
		{
			animator.SetInteger("Direction", 3);
		}
		else if (horizontal < 0)
		{
			animator.SetInteger("Direction", 1);
		}
		else if (horizontal == 0 && vertical == 0)
		{
			//num = 4 + animator.GetInteger ("Direction");
			animator.SetInteger("Direction", animator.GetInteger ("Direction")+4);
		}

	}
}