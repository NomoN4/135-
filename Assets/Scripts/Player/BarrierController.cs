using UnityEngine;

public class BarrierController : MonoBehaviour
{
    [SerializeField] private GameObject barrierObject;

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();

        UpdateBarrier();
    }

    void Update()
    {
        UpdateBarrier();
    }

    void UpdateBarrier()
    {
        barrierObject.SetActive(playerStats.barrier);
    }
}