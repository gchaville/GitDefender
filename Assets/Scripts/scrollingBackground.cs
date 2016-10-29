﻿using UnityEngine;
using System.Collections;

public class scrollingBackground : MonoBehaviour
{

    public float speed = 0.5f;
    Renderer renderer;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 offset = new Vector2(Time.time * speed, 0);
        renderer.material.mainTextureOffset = offset;

    }
}



