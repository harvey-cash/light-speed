using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe {

    /* Accessed by all Views */
    public static float time = 0; // seconds

    private static int lastID = 0;
    public static int UniqueID() { return lastID++; }

    // Progress the simulation
    public float Tick(float dT) {
        time += dT;
        return time;
    }

}
