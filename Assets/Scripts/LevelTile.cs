using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelTile : MonoBehaviour    
{

    [SerializeField]
    public int tileID;
    public int tileType;
    public List<Sprite> SpriteList;

    // Start is called before the first frame update
   
    public void ChangeDisplay (int index)
    {
        SpriteRenderer spriteRenderer;

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = SpriteList[tileID];
        
    }
}
