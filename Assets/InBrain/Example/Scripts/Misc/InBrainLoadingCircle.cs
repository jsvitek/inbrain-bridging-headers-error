﻿using UnityEngine;

namespace InBrain
{
	public class InBrainLoadingCircle : MonoBehaviour
	{
		[SerializeField] float rotateSpeed = 200f;

		RectTransform _rectComponent;

		void Start()
		{
			_rectComponent = GetComponent<RectTransform>();
		}

		void Update()
		{
			_rectComponent.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
		}
	}
}