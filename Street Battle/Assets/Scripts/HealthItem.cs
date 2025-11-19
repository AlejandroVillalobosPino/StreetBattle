using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healAmount = 2;
    public AudioClip healSound;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.Heal(healAmount);

            if (healSound != null)
            {
                player.PlaySong(healSound);
            }

            Destroy(gameObject);
        }
    }
}

