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
    float angularVel = (2 * Mathf.PI) / 15; // rads per second

    // For the given time, get the position of an object on this trajectory
    public Vector3 GetPosition(float time) {
        float currentRads = GetTrueAnomaly(time);
        float x = center.x + (radius * Mathf.Sin(currentRads));
        float z = center.z + (radius * Mathf.Cos(currentRads));

        return new Vector3(x, 0, z);
    }

    // Get the true anomaly at a given time
    public float GetTrueAnomaly(float time) {
        return Mathf.Repeat((angularVel * (time - startTime)) - startRads, Mathf.PI * 2);
    }

    // GetPositions along path given a set of trueAnomalies
    // The trueAnomaly is the angle from the periapsis line in radians
    public Vector3[] GetPositionSamples(float[] trueAnomalies) {
        Vector3[] positions = new Vector3[trueAnomalies.Length];

        for (int i = 0; i < trueAnomalies.Length; i++) {
            float trueAnomaly = trueAnomalies[i];
            positions[i] = GetPositionSample(trueAnomaly);
        }

        return positions;
    }

    // Get the coordinates of the path for a given trueAnomaly
    // The trueAnomaly is the angle from the periapsis line in radians
    public Vector3 GetPositionSample(float trueAnomaly) {
        // ToDo: Replace circular orbits with elliptical

        // A circle has no periapsis, so use startRads
        float angle = startRads + trueAnomaly;
        float x = center.x + (radius * Mathf.Sin(angle));
        float z = center.z + (radius * Mathf.Cos(angle));

        return new Vector3(x, 0, z);
    }

    // For a given time and change in velocity, return the resultant trajectory
    public static Trajectory Manoeuvre (int timeNow, Trajectory trajectoryCurrent, Vector3 dV) {
        return trajectoryCurrent;
    }
}
