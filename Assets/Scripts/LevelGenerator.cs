using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelGenerator : MonoBehaviour
{
    public int EditingCurrentLevel = 0;
    public float xStart;
    public float yStart;
    public float xOffset;
    public float yOffset;

    public Transform LevelParent;
    public GameObject tilePrefab;

    public List<LevelData> LevelsList;

    public List<LevelTile> TileList;


    // Start is called before the first frame update
    void Start()
    {
        //LevelsList = new List<LevelData>();
       // TileList = new List<LevelTile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateLevel(int level =0)
    {
        GameObject temp;
        ClearLevel();
        //LevelParent.position = Vector3.zero;
        TileList.Clear();
        TileList = new List<LevelTile>();
        for (int i=0;i<18; i++)
        {
            for (int j=0;j<11;j++)
            {
                temp = Instantiate(tilePrefab, LevelParent);                
                temp.transform.localPosition = new Vector3(xStart + (xOffset * j), (yStart + yOffset*i)*-1,0);
               // temp.transform.parent = LevelParent;
                TileList.Add(temp.GetComponent<LevelTile>());
            }
        }

        //LevelParent.position = new Vector3(-2.25f, 4, 0);
    }

    public void LoadLevel(int level = 0)
    {

      for (int i=0;i< LevelsList[EditingCurrentLevel].LevelTiles.Count;i++)
        {
            TileList[i].tileID = LevelsList[EditingCurrentLevel].LevelTiles[i];
        }
        RefreshTiles();
    }

    public void SaveLevel(int level = 0)
    {
        LevelsList[EditingCurrentLevel].LevelTiles = new List<int>();

       foreach (LevelTile tile in TileList)
        {
            LevelsList[EditingCurrentLevel].LevelTiles.Add(tile.tileID);
        }
    }

    public void RefreshTiles ()
    {
        foreach (LevelTile tile in TileList)
        {
            tile.ChangeDisplay(0);
        }
    }

    public void ClearLevel()
    {
       for (int i=TileList.Count-1;i> -1;i--)
        {
            DestroyImmediate(TileList[i].gameObject);
        }
        TileList.Clear();
        TileList = new List<LevelTile>();
    }
}
