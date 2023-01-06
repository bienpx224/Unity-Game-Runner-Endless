using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxHandler : MonoBehaviour
{
	[SerializeField]private float _duration = 1f;
	private float _elapsedTime;
	private void Update()
	{
		if(_elapsedTime<0)
		{
			_elapsedTime += Time.deltaTime;
			if(_elapsedTime>=0)
			{
				OnDespawn();
			}
		}
	}
	private void OnEnable()
	{
		_elapsedTime = -_duration;
	}

	public void Deactive()
	{
		gameObject.SetActive(false);
	}
	public void OnDespawn()
	{
		Lean.Pool.LeanPool.Despawn(this);
	}
}
