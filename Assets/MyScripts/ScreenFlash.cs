using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ScreenFlash : MonoBehaviour
{
    [SerializeField] private float _flashDuration = 0.33f;
    [SerializeField] private Image _flashImage;
    [SerializeField] private Color _imageColour;

    private void OnEnable()
    {
        StartCoroutine(FlashRoutine());
    }

    void Start()
    {
        _flashImage = GetComponent<Image>();
        _imageColour = _flashImage.color;
        MoveShip ship = GetComponent<MoveShip>();
    }

    public IEnumerator FlashRoutine()
    {
        float timer = 0f;
        float t = 0f;
        float alphaFrom = 1f;
         float alphaTo = 0f;

        while (t < 1f)
        {
            timer += Time.deltaTime;
            t = Mathf.Clamp01(timer / _flashDuration);
            float alpha = Mathf.Lerp(alphaFrom, alphaTo, t);
            Color col = _imageColour;
            col.a = alpha;
            _flashImage.color = col;
            yield return new WaitForEndOfFrame();
        }
    }
}
