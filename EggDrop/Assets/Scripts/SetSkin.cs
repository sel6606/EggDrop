using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetChosenTexture()
    {
        
    }

    private void SetAppropriateParticle(Texture texture)
    {
        switch (texture.name)
        {
            case "cape-texture":
                GameInfo.instance.ParticleColor = Color.HSVToRGB(0.32f, 0.69f, 0.90f);

                break;
            case "fancy-texture":
                GameInfo.instance.ParticleColor = Color.HSVToRGB(0.32f, 0.69f, 0.90f);

                break;
            case "kiwi-texture":
                GameInfo.instance.ParticleColor = Color.HSVToRGB(0.32f, 0.69f, 0.90f);

                break;
            case "wings-texture":
                GameInfo.instance.ParticleColor = Color.HSVToRGB(0.32f, 0.69f, 0.90f);

                break;
            case "yolk-texture":
                GameInfo.instance.ParticleColor = Color.HSVToRGB(2.71f, 0.81f, 0.17f);

                break;
            default:
                GameInfo.instance.ParticleColor = Color.HSVToRGB(0.32f, 0.69f, 0.90f);

                break;
        }
    }
}
