using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public void StartShake(MultipleCasterCameraShake cast)
    {
        StartCoroutine(Shake(cast));
    }

    public IEnumerator Shake(MultipleCasterCameraShake cast)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < cast.shakeTime)
        {
            float x = Random.Range(-1f, 1f) * cast.shakeMagnitude;
            float y = Random.Range(-1f, 1f) * cast.shakeMagnitude;

            transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}
