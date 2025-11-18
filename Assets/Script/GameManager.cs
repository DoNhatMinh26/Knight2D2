using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text health;
    [SerializeField] private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UiHealth();
    }
    private void UiHealth()
    {
        health.text = player.MaxHealth.ToString();
    }
}
