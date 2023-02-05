using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRoot : MonoBehaviour
{
    int RootID;
    List<List<LevelTile>> RootSystem;
    public LevelTile rootTile;

    public List<int> ResourceToCollect;
    int resourcesCollected = 0;

    int branches = 0;

    public int Branches { get => branches; set => branches = value; }

    // Start is called before the first frame update
    void Start()
    {
        RootSystem = new List<List<LevelTile>>();
        for (int i=0;i<3;i++)
        {
            RootSystem.Add(new List<LevelTile>());
        }

        RootSystem[0].Add(rootTile);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearRoots()
    {
        for (int i=0;i<3;i++)
        {
            foreach (LevelTile tile in RootSystem[i])
            {
                tile.ResetTile();
            }
        }
    }

    public void AddTileToRoot (LevelTile tileRef, int branch)
    {
        Debug.Log("Adding Tile at index" + branch);
        
        if (tileRef.tileType == 1)
        {
            RootSystem[branch].Add(tileRef);
        }
        
       else
        {
            if (ResourceToCollect.Contains (tileRef.tileType))
            {
                if (ResourceToCollect.Contains(tileRef.tileType))
                {
                    ResourceToCollect.Remove(tileRef.tileType);
                    Debug.Log("resource collected");
                    resourcesCollected++;
                }
               
                if (ResourceToCollect.Count<1)
                {
                    //complete level
                    Debug.Log("level Complete");
                    //SceneHandler.Instance.
                }
            }
        }
       
    }

    public void AddBranch ()
    {
        if (Branches < 2)
        {
            Branches++;
        }
    }

    public void SetRootID (int id)
    {
        RootID = id;
    }

    public bool RootIDCompare (int id)
    {
        if (id == RootID)
            return true;
        else
            return false;
    }


    public bool VerifyActiveTile (LevelTile tile)
    {

        for (int i=0;i<3;i++)
        {

            if (RootSystem[i].Count < 1)
            {
                Debug.Log("Index" + i+ "Count is "+ RootSystem[i].Count);
                return false;
            }


            if (RootSystem[i].IndexOf(tile) == (RootSystem[i].Count - 1) )
            {
                Debug.Log("Active tile" + i);
                return true;
            } else
            {
                Debug.Log("Inactive tile" + RootSystem[i].IndexOf(tile) + "Not matching with" + (RootSystem[i].Count - 1) + "On branch" + i + "Branch lengths are 0" + RootSystem[0].Count + "1" + +RootSystem[1].Count + "2"+ RootSystem[2].Count + " done" );
            }
        }

        return false;
    }

}
