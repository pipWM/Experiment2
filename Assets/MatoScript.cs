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
		// ������
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
		// �c�莞�Ԃ��X�V
		currentRemainTime -= Time.deltaTime;

		if (currentRemainTime <= 0f)
		{
			// �c�莞�Ԃ������Ȃ����玩�����g������
			GameObject.Destroy(gameObject);
			return;
		}

		// �t�F�[�h�A�E�g
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
