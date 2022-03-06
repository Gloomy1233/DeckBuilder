using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TweenCards : MonoBehaviour
{
	//public Transform target; // Target to follow
	Vector3 targetLastPos,StartingPosition;
	Tweener tween;
	public bool disabled=false;

	void Start()
	{
		// First create the "move to target" tween and store it as a Tweener.
		// In this case I'm also setting autoKill to FALSE so the tween can go on forever
		// (otherwise it will stop executing if it reaches the target)
		StartingPosition = gameObject.transform.position;
		tween = transform.DOMove(Input.mousePosition, 0.5f).SetAutoKill(false);
		// Store the target's last position, so it can be used to know if it changes
		// (to prevent changing the tween if nothing actually changes)
		targetLastPos = Input.mousePosition;
	}

	void Update()
	{

		if (!disabled)
		{
			// Use an Update routine to change the tween's endValue each frame
			// so that it updates to the target's position if that changed
			if (targetLastPos == Input.mousePosition) return;
			// Add a Restart in the end, so that if the tween was completed it will play again
			tween.ChangeEndValue(Input.mousePosition, true).Restart();
			targetLastPos = Input.mousePosition;
		}else if (disabled)
        {
			gameObject.transform.position = StartingPosition;
		}
		
	}
    private void OnDisable()
    {
		
		disabled = true;

	}


}
