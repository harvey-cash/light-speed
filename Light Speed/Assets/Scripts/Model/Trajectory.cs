using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory
{
    /* Trajectories encode the orbit of a body.
     * A trajectory has a fixed position at a given time.
     * 
     * Temporarily using circular orbits in order to build visualisation.
     */
    float startRads = 0;
    float startTime = 0;
    Vector3 center = Vector3.zero;
    float radius = Sun.radius + (10 ^ 3); // metres
    float angularVel = (2 * Mathf.PI) / 30; // rads per second

    // For the given time, get the position of an object on this trajectory
    public Vector3 GetPosition(float time) {
        float currentRads = (angularVel * (time - startTime)) - startRads;
        float x = center.x + (radius * Mathf.Sin(currentRads));
        float z = center.z + (radius * Mathf.Cos(currentRads));

        Debug.Log("Sun: " + Sun.radius.ToString());
        Debug.Log(x);

        return new Vector3(x, 0, z);
    }

    // For a given time and change in velocity, return the resultant trajectory
    public static Trajectory Manoeuvre (int timeNow, Trajectory trajectoryCurrent, Vector3 dV) {
        return trajectoryCurrent;
    }
}
