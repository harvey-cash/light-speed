using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewProbe : MonoBehaviour
{
    public Probe probe;

    public void UpdatePosition(float time) {
        Vector3 modelPosition = probe.trajectory.GetPosition(time);

        Debug.Log("modelPos: " + modelPosition.ToString());

        Vector3 position = modelPosition / Constants.MODEL_SCALE;

        Debug.Log("pos: " + position.ToString());

        transform.localPosition = position;
    }
}
