using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootBehaviour : MonoBehaviour
{

    bool isActiveRoot = false;
    TreeRoot currentRoot;
    int currentBranch;

    LevelTile currentActiveTile;


    // Start is called before the first frame update
    void Start()
    {
        currentBranch = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastfindPath();
        }else
        {
            isActiveRoot = false;
        }
    }


    void RaycastfindPath()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            //Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            if (hit.collider.GetComponent<LevelTile>())
            {
                ProcessTile(hit.collider.GetComponent<LevelTile>());
            }
        }
    }

    void ProcessTile(LevelTile tile)
    {
        if (tile.tileType == 1 )
        {

            if (tile.parentRoot.VerifyActiveTile(tile))
            {
                isActiveRoot = true;
                currentRoot = tile.parentRoot;
                currentBranch = tile.branchIndex;
                currentActiveTile = tile;
            } else if (tile.parentRoot.Branches<2)
            {

                isActiveRoot = true;
                currentRoot = tile.parentRoot;
                currentBranch = tile.branchIndex;
                currentActiveTile = tile;
            }
        } else   if(tile.tileType == 0 && isActiveRoot)
        {

            if (currentActiveTile.parentRoot.VerifyActiveTile(currentActiveTile))
            {
               
                
                tile.DisplayRootOnTile(true, 1, currentRoot, currentBranch);
                tile.parentRoot.AddTileToRoot(tile, currentBranch);
            } 
                else if (currentActiveTile.parentRoot.Branches<2)
            {
                currentActiveTile.parentRoot.AddBranch();
                currentBranch = currentActiveTile.parentRoot.Branches;

                tile.DisplayRootOnTile(true, 1, currentRoot, currentBranch);
                tile.parentRoot.AddTileToRoot(tile, currentBranch);
               
            }
           
        } else if (isActiveRoot)
        {
            tile.DisplayRootOnTile(false, tile.tileType, currentRoot, currentBranch);
            tile.parentRoot.AddTileToRoot(tile, currentBranch);
        }
    }


}
