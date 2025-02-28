using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoostBar : MonoBehaviour
{
    [SerializeField] private GameObject fillImage;
    [SerializeField] private Image bar;
    [SerializeField] private float duration = 5f;

    public static BoostBar boostbar;

    private void Awake()
    {
        boostbar = this;
        bar = fillImage.GetComponentInChildren<Image>();
    }

    public IEnumerator DecreaseBar()
    {
        fillImage.SetActive(true);
        bar.fillAmount = 1f;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            bar.fillAmount = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        bar.fillAmount = 0f;
        fillImage.SetActive(false);
    }
}
