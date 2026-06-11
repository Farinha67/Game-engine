using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    public int zombiesPorOnda = 3;

    public float tempoEntreOndas = 30f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnarOnda), 0f, tempoEntreOndas);
    }

    void SpawnarOnda()
    {
        for (int i = 0; i < zombiesPorOnda; i++)
        {
            Vector3 posicaoAleatoria =
                transform.position +
                new Vector3(
                    Random.Range(-2f, 2f),
                    0,
                    Random.Range(-2f, 2f)
                );

            Instantiate(
                zombiePrefab,
                posicaoAleatoria,
                Quaternion.identity
            );
        }
    }
}   