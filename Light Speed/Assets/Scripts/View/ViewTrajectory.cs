using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTrajectory : MonoBehaviour
{
    public Trajectory trajectory { private get; set; }
    private LineRenderer lineRenderer;

    private static int samples = 90;
    private static float radsPerSample = 2 * Mathf.PI / samples;

    public void Init(Trajectory t) {
        trajectory = t;

        lineRenderer = GetComponent<LineRenderer>();
        if (!lineRenderer) {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        PlotTrajectory();
    }

    public void PlotTrajectory() {
        Vector3[] positions = new Vector3[samples];

        for (int i = 0; i < samples; i++) {
            float trueAnomaly = i * radsPerSample;
            Vector3 position = trajectory.GetPositionSample(trueAnomaly);
            positions[i] = position / Constants.MODEL_SCALE; // reduce scale

            Debug.Log(positions[i]);
        }

        lineRenderer.positionCount = samples; // Number of vertices
        lineRenderer.SetPositions(positions);

        // Connect to form a continuous orbit
        lineRenderer.loop = true;
    }

    public void AnimateTrajectory(float time) {
        float trueAnomaly = trajectory.GetTrueAnomaly(time);
        float proportion = trueAnomaly / (2 * Mathf.PI);
        // Set colours
        lineRenderer.colorGradient = GetGradient(proportion);
    }

    // Create a gradient based on the current position along path
    private Gradient GetGradient(float proportion) {
        Color nowColor = new Color(0.2f, 0.2f, 0.8f);
        float nowAlpha = 1f;
        Color endColor = new Color(0.1f, 0.1f, 0.5f);
        float endAlpha = 0.5f;

        Gradient gradient = new Gradient();

        // Populate color and alpha along the path
        GradientColorKey[] colorKey = new GradientColorKey[4];
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[4];

        // At the periapsis
        colorKey[0].color = Color.Lerp(endColor, nowColor, proportion);
        alphaKey[0].alpha = Mathf.Lerp(endAlpha, nowAlpha, proportion);
        colorKey[0].time = alphaKey[0].time = 0f;

        // At the object
        colorKey[1].color = endColor;
        alphaKey[1].alpha = endAlpha;
        colorKey[1].time = alphaKey[1].time = proportion;

        // Just ahead of the object
        colorKey[2].color = nowColor;
        alphaKey[2].alpha = nowAlpha;
        colorKey[2].time = alphaKey[2].time = Mathf.Clamp(proportion + 0.01f, 0f, 1f);

        // Just before the periapsis
        colorKey[3].color = Color.Lerp(endColor, nowColor, proportion);
        alphaKey[3].alpha = Mathf.Lerp(endAlpha, nowAlpha, proportion);
        colorKey[3].time = alphaKey[3].time = 0.99f;

        if (proportion > 0.99f) {
            colorKey[0].color = nowColor;
            alphaKey[0].alpha = nowAlpha;

            colorKey[3].color = endColor;
            alphaKey[3].alpha = endAlpha;
        }

        gradient.SetKeys(colorKey, alphaKey);
        return gradient;
    }
}
