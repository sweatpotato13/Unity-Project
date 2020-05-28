﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombButton2 : MonoBehaviour
{
    private int BombCount;
    public List<Button> buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MeteorAttack(string tag)
    {
        BombCount = PlayerPrefs.GetInt("Bomb");
        if (BombCount > 0)
        {
            BombCount -= 1;
            if (BombCount == 0)
            {
                GameObject[] buttonObjects = GameObject.FindGameObjectsWithTag("BombButton");
                for (int i=0; i < buttonObjects.Length; i++)
                {
                    buttons.Add(buttonObjects[i].GetComponent<Button>());
                }
                for (int i=0; i < buttons.Count; i++)
                {
                    buttons[i].interactable = false;
                }
            }
            PlayerPrefs.SetInt("Bomb", BombCount);
            ParticleSystem ps = GameObject.Find("MeteorParticle").GetComponent<ParticleSystem>();
            ps.Play();
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject target in gameObjects)
            {
                GameObject.Destroy(target);
            }
        }
    }
}