using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        spawnedChunks.Add(FirstChunk);
    }

    private void Update()
    {
        if (Player.position.y < spawnedChunks[spawnedChunks.Count - 1].End.position.y + 15)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);
        if (spawnedChunks.Count >= 5)
        {
           Destroy(spawnedChunks[0].gameObject);
           spawnedChunks.RemoveAt(0);
        }
    }

    /*private Chunk GetRandomChunk()
    {
        List<float> chances = new List<float>();
        float value = Random.Range(0, chances.Sum());
        float sum = 0;
    
        for (int i = 0; i < chances.Count; i++)
        {
              sum += chances[i];
            if (value < sum)
            {
                return ChunkPrefabs[i];
            }
        }

        return ChunkPrefabs[ChunkPrefabs.Length - 1];
    }
    */
}
