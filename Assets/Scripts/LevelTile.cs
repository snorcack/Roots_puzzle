using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelTile : MonoBehaviour    
{

    [SerializeField]
    public int tileID;
    public int tileType;
    public List<Sprite> SpriteList;
    public SpriteRenderer rootRef;

    public TreeRoot parentRoot;
    public int branchIndex = 50;

    // Start is called before the first frame update
   
    public void ChangeDisplay (int index)
    {
        SpriteRenderer spriteRenderer;

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = SpriteList[tileID];
        
    }


    public void DisplayRootOnTile (bool status, int inTileType, TreeRoot parentRef , int parentBranch)
    {
        rootRef.enabled = status;

        tileType = inTileType;
        parentRoot = parentRef;
        branchIndex = parentBranch;

        Debug.Log("Setting values as" + status + inTileType + parentRef.name + parentBranch);
    }

    public void ResetTile ()
    {
        tileType = 0;
        parentRoot = null;
        branchIndex = 50;
        rootRef.enabled  = false;
    }

}
