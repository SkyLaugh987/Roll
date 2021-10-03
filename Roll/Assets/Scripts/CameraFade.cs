using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public AnimationCurve FadeCurve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(0.6f, 0.7f, -1.8f, -1.2f), new Keyframe(1, 0));

    private float alpha = 1;
    private Texture2D texture;
    private bool done;
    private float time;

    public void Reset()
    {
        done = false;
        alpha = 1;
        time = 0;
    }

    [RuntimeInitializeOnLoadMethod]
    public void RedoFade()
    {
        Reset();
    }

    public void OnGUI()
    {
        if (done){
            return;
        }
        if (texture == null){
            texture = new Texture2D(1, 1);
        }

        texture.SetPixel(0, 0, new Color(0, 0, 0, alpha));
        texture.Apply();

        time += Time.deltaTime;
        alpha = FadeCurve.Evaluate(time);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);

        if (alpha <= 0){
            done = true;
        }
    }
}
