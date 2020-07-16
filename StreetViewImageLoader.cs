using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class StreetViewImageLoader : MonoBehaviour {

    public double heading = 0.0;
    public double pitch = 0.0;

    private int width = 640;
    private int height = 480;

    private double longitude = 135.5216538;
    private double latitude = 34.8216886;

    

    Texture texture;
    [SerializeField]Material material;

    // Use this for initialization
    void Start () {
        StartCoroutine(GetStreetViewImage(latitude, longitude, heading, pitch));
    }

    private IEnumerator GetStreetViewImage(double latitude, double longitude, double heading, double pitch) {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://maps.googleapis.com/maps/api/streetview?" + "size=" + width + "x" + height + "&location=" + latitude + "," + longitude + "&heading=" + heading + "&pitch=" + pitch + "&fov=90&sensor=false" + "&key=YourAPIKEY");
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            material.SetTexture("_MainTex", texture);

            gameObject.GetComponent<Renderer>().material = material;
        }
    }
}