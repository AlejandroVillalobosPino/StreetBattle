using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damageIncrease = 1; // Cantidad de daño adicional
    public AudioClip pickupSound; // Sonido al recoger el ítem (opcional)

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisionó es el jugador
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log("Jugador detectado. Buscando hijo llamado 'Attack'...");

            // Busca al objeto hijo llamado "Attack"
            Transform attackTransform = player.transform.Find("Attack");

            if (attackTransform != null)
            {
                // Obtiene el componente Attack del objeto encontrado
                Attack attack = attackTransform.GetComponent<Attack>();
                if (attack != null)
                {
                    Debug.Log($"Incrementando daño en {damageIncrease}. Daño actual: {attack.damage}");
                    attack.damage += damageIncrease; // Incrementa el daño
                    Debug.Log($"Nuevo daño: {attack.damage}");
                }
                else
                {
                    Debug.LogWarning("El objeto 'Attack' no tiene un componente Attack adjunto.");
                }
            }
            else
            {
                Debug.LogWarning("No se encontró un hijo llamado 'Attack' en el jugador.");
            }

            // Reproduce el sonido de recogida si está configurado
            if (pickupSound != null)
            {
                player.PlaySong(pickupSound);
            }

            // Destruye el objeto de mejora de arma
            Destroy(gameObject);
        }
    }
}
