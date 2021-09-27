using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatoScript : MonoBehaviour
{
	public float fadeTime = 5f;

	private float currentRemainTime;
	private SpriteRenderer spRenderer;

	private float StartTime;
	private bool isCountDown = false;
	public bool isFirstCondition;
	// Use this for initialization
	void Start()
	{
		StartTime = Time.time;
		// 初期化
		if (isFirstCondition) startCountDown();
	}

	// Update is called once per frame
	void Update()
	{
		
		if(isCountDown && Time.time - StartTime >= fadeTime)
        {
			/*
            if (!IsStart)
            {
				currentRemainTime = fadeTime;
				spRenderer = GetComponent<SpriteRenderer>();
				IsStart = true;
            }
            else
            {
				Fade();
            }*/
			Destroy(this.gameObject);
        }
	}

	void Fade()
    {
		// 残り時間を更新
		currentRemainTime -= Time.deltaTime;

		if (currentRemainTime <= 0f)
		{
			// 残り時間が無くなったら自分自身を消滅
			GameObject.Destroy(gameObject);
			return;
		}

		// フェードアウト
		float alpha = currentRemainTime / fadeTime;
		var color = spRenderer.color;
		color.a = alpha;
		spRenderer.color = color;
	}

	public void startCountDown()
    {
		isCountDown = true;
		StartTime = Time.time;
	}

	public void Destroy()
    {
		Destroy(this.gameObject);
	}
}
