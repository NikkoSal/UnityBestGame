using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [Header("Note Settings")]
    public GameObject notePrefab;        // Префаб ноты
    public GameObject[] laneStart;       // Точки по X, где спавнятся ноты

    [Header("Music Settings")]
    public AudioSource audioSource;      // Источник музыки
    public float bpm = 120f;             // Темп в ударах в минуту

    [Header("Spawn Settings")]
    public float spawnZ = 20f;           // Расстояние от игрока по оси Z

    private float interval;              // Интервал между нотами
    private float lastNoteTime;          // Когда последняя нота была создана

    void Start()
    {
        if (laneStart.Length != 4)
        {
            Debug.LogError("Требуется ровно 4 точки старта в массиве laneStart.");
            return;
        }

        interval = 60f / bpm;
        lastNoteTime = 0f;

        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource не содержит аудиоклип.");
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying) return;

        float currentTime = audioSource.time;

        while (currentTime - lastNoteTime >= interval)
        {
            SpawnNote();
            lastNoteTime += interval;
        }
    }

    void SpawnNote()
    {
        int randLane = Random.Range(0, laneStart.Length);
        Vector3 basePos = laneStart[randLane].transform.position;

        Vector3 spawnPos = new Vector3(
            basePos.x,
            basePos.y,
            spawnZ // спавним далеко по Z
        );

        Instantiate(notePrefab, spawnPos, Quaternion.identity);
    }
}
