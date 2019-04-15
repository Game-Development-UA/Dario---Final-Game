using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public List<Transform> checkPoints = new List<Transform>();
    public List<Vector3> pathLines = new List<Vector3>();
    public static Path Singleton;
    
    // Start is called before the first frame update

    void Awake() {
        Singleton = this;
    }

    void Start() {
        for (int i = 1; i < checkPoints.Count; i++) {
            pathLines.Add(checkPoints[i].position - checkPoints[i - 1].position);
        }

    }

    public bool CheckConflictTowerPosition(Vector3 towerPosition) {
        for (int i = 0; i < pathLines.Count; i++) {
            
            RaycastHit2D[] hit = Physics2D.RaycastAll(checkPoints[i].position, pathLines[i], Vector3.Magnitude(pathLines[i]));
            print(pathLines[i]);
            print(hit.Length);
            for (int j = 0; j < hit.Length; j++) {
                if (hit[j].collider.tag == "tower")
                {
                    UIManager.Singleton.UpdateTextBox("Cannot place tower on Enemy Path");
                    return false;
                }
            }
            
        }
        return true;

    }



}
