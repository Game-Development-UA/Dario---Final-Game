using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public List<Transform> checkPoints = new List<Transform>();
    public static Path Singleton;
    // Start is called before the first frame update

    void Awake() {
        Singleton = this;
    }

}
