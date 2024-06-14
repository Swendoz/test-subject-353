using UnityEngine;
using UnityEngine.UI;

public class CameraToUI : MonoBehaviour
{
    public RawImage rawImage;
    public Camera liveCamera;

    void Update()
    {
        Texture texture = liveCamera.targetTexture;
        rawImage.texture = texture;
    }
}
