using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
public class Path : MonoBehaviour, IPointerClickHandler
{
   public bool acceptableLocation;
    public List<Transform> checkPoints = new List<Transform>();
    public List<Vector3> pathLines = new List<Vector3>();
    public Tilemap pathTiles;
    public static Path Singleton;
    
    // Start is called before the first frame update

    void Awake() {
        Singleton = this;
    }

    void Start() {
        for (int i = 1; i < checkPoints.Count; i++) {
            pathLines.Add(checkPoints[i].position - checkPoints[i - 1].position);
        }
        acceptableLocation = true;
    }

    public bool CheckConflictTowerPosition(Vector3 towerPosition)
    {
        bool returnValue;
        print(pathTiles.HasTile(Vector3Int.RoundToInt(towerPosition)));
        if (pathTiles.HasTile(Vector3Int.RoundToInt(towerPosition)))
            {
            print(pathTiles.HasTile(Vector3Int.RoundToInt(towerPosition)));
            UIManager.Singleton.UpdateTextBox("Cannot place tower on Enemy Path");
                returnValue = false;
            }
            else
            {
            print(pathTiles.HasTile(Vector3Int.RoundToInt(towerPosition)));
                returnValue = true;
            }
        return returnValue;
        
    }

    public void OnTriggerEnter2D(Collider2D col) {
        print("hi");
        if (col.gameObject.tag == "tower") {
            UIManager.Singleton.UpdateTextBox("Cannot place tower on Enemy Path");
            

        }
    }

    public void OnPointerClick(PointerEventData data) {

    }



}
