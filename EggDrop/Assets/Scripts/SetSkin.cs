using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to set the correct texture and particle selected from the shop.
/// </summary>
public class SetSkin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Sets the texture according to the one selected in the shop.
    /// </summary>
    public void SetChosenTexture()
    {
        //Set the texture according to the one selected
        //GameInfo.instance.CurrTexture =

        SetAppropriateParticle(GameInfo.instance.CurrTexture);
    }

    /// <summary>
    /// Sets the particle color according to the texture
    /// </summary>
    /// <param name="texture">the texure of the egg</param>
    private void SetAppropriateParticle(Texture texture)
    {
        switch (texture.name)
        {
            case "yolk-texture":
                GameInfo.instance.ParticleColor = new Color32(26, 8, 43, 255);

                break;
            default:
                GameInfo.instance.ParticleColor = new Color32(247, 230, 211, 255);

                break;
        }
    }
}
