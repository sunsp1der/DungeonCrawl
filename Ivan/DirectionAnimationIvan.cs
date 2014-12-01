using UnityEngine;
using System.Collections;

public class DirectionAnimationIvan : MonoBehaviour
{
	int num; // IVAN: what is this?
	private Animator animator;

	public float horizontalCollideWidth = 1.0f; // width of player sprite when moving horizontally
	public float verticalCollideWidth = 1.5f; // width of player sprite when moving vertically
	BoxCollider2D[] colliders;
	
	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>(); // IVAN: "this." at beginning was unneccessary
		// GetComponentsInChildren gets all the components in this object and it's children in
		// the scene hierarchy.
		colliders = GetComponentsInChildren<BoxCollider2D>(); 
	}
	
	// Update is called once per frame
	void Update() // IVAN:  doesn't need to be tested more than once per frame, so use Update not FixedUpdate
	{
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		if (horizontal == 0 && vertical == 0)
		{
			animator.SetInteger("Direction", animator.GetInteger ("Direction")+4);
		}
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

		// alter hit box depending on direction of movement, because shape changes
		int direction = animator.GetInteger ("Direction");
		float collideWidth;
		if (direction == 3 || direction == 1 || direction == 7 || direction == 5) {
			collideWidth = horizontalCollideWidth;
		}
		else {
			collideWidth = verticalCollideWidth;
		}
		foreach (BoxCollider2D collider in colliders) {
			collider.size = new Vector2 (collideWidth, collider.size.y);
		}

		// IVAN: Commented this stuff out because it doesn't do anything
		//if (animator.GetInteger ("Direction") > 7) 
		//{
		//	animator.SetInteger("Direction", animator.GetInteger ("Direction")-4);
		//}
		//print (animator.GetInteger ("Direction"));
	}
}