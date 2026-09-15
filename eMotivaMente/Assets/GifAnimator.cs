using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GifAnimator : MonoBehaviour
{
    public Image image;
    public Sprite[] frames;
    public float fps = 12f;

    private int currentFrame;
    private float timer;

    void Start()
    {
        image.sprite = frames[0];
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.1f)
        {
            timer = 0f;

            currentFrame++;

            if (currentFrame >= frames.Length)
                currentFrame = 0;

            image.sprite = frames[currentFrame];
        }
    }
}
