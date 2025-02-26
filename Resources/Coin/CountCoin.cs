using UnityEngine;
using UnityEngine.UI;

public class CountCoin : MonoBehaviour
{
    [SerializeField] private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        text.text = Player.instance.coins.ToString();
    }
}
