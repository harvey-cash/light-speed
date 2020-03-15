using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewProbe : MonoBehaviour
{
    public Probe probe { get; private set; }
    private ViewTrajectory viewTrajectory;

    public void Init(Probe p) {
        probe = p;
        CreateTrajectory(p);
    }

    // Set the ViewTrajectory. Create if one doesn't exist
    public void CreateTrajectory(Probe p) {
        viewTrajectory = GetComponent<ViewTrajectory>();
        if (!viewTrajectory) {
            viewTrajectory = gameObject.AddComponent<ViewTrajectory>();
        }
        viewTrajectory.Init(probe.trajectory);
    }

    public void Update() {
        UpdatePosition(Universe.time);
        viewTrajectory.AnimateTrajectory(Universe.time);
    }

    public void UpdatePosition(float time) {
        Vector3 modelPosition = probe.trajectory.GetPosition(time);
        Vector3 position = modelPosition / Constants.MODEL_SCALE;
        transform.localPosition = position;
    }
}
