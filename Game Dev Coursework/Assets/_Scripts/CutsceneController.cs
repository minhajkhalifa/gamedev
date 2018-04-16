using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class CutsceneController : MonoBehaviour
{
    public Image imageFade;
    //public Transform cameraEndPosition;
    private Transform cam;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(PlayerCutscene());
    }

    private IEnumerator PlayerCutscene()
    {
        cam = GetComponent<Camera>().transform;
        float cameraAngle = 360f;

        yield return new WaitForSeconds(1);
        // fade in and do camera move
        imageFade.DOFade(0, 2);
        //yield return new WaitForSeconds(1);
        //cam.DORotate(cam.position, 10);
        while (cameraAngle > 0f)
        {
            float angle = 200 * Time.deltaTime;
            cam.RotateAround(PlayerCarChoice.playerCar.transform.position, Vector3.up, angle);
            cameraAngle -= angle;
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.SetActive(false);
        //yield return new WaitForSeconds(2);
    }
}
