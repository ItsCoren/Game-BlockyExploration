using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageScroller : MonoBehaviour
{
	[SerializeField] RawImage img;
	[SerializeField] Vector2 move;

	// Update is called once per frame
	void Update()
	{
		img.uvRect = new Rect(img.uvRect.position + move * Time.unscaledDeltaTime, img.uvRect.size);
	}
}
