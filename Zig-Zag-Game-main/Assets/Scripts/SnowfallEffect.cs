using UnityEngine;

// Automatically adds gentle snowfall to the game when a scene starts.
public class SnowfallEffect : MonoBehaviour
{
    private ParticleSystem snow;
    private Camera targetCamera;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void AddSnowToScene()
    {
        if (FindObjectOfType<SnowfallEffect>() != null) return;
        var snowObject = new GameObject("Snowfall Effect");
        DontDestroyOnLoad(snowObject);
        snowObject.AddComponent<SnowfallEffect>();
    }

    private void Start()
    {
        targetCamera = Camera.main;
        snow = gameObject.AddComponent<ParticleSystem>();
        var main = snow.main;
        main.loop = true;
        main.playOnAwake = true;
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        main.maxParticles = 1800;
        main.startLifetime = new ParticleSystem.MinMaxCurve(5f, 9f);
        main.startSpeed = new ParticleSystem.MinMaxCurve(0.8f, 2.0f);
        main.startSize = new ParticleSystem.MinMaxCurve(0.035f, 0.11f);
        main.startColor = new Color(1f, 1f, 1f, 0.9f);
        main.gravityModifier = 0.12f;

        var emission = snow.emission;
        emission.rateOverTime = 170f;

        var shape = snow.shape;
        shape.shapeType = ParticleSystemShapeType.Box;
        shape.scale = new Vector3(24f, 0.1f, 20f);

        var velocity = snow.velocityOverLifetime;
        velocity.enabled = true;
        velocity.x = new ParticleSystem.MinMaxCurve(-0.25f, 0.25f);
        velocity.y = new ParticleSystem.MinMaxCurve(-0.4f, 0.1f);
        velocity.z = new ParticleSystem.MinMaxCurve(-0.2f, 0.2f);

        var renderer = snow.GetComponent<ParticleSystemRenderer>();
        renderer.renderMode = ParticleSystemRenderMode.Billboard;
        renderer.material = new Material(Shader.Find("Sprites/Default"));
        renderer.material.color = Color.white;
        snow.transform.position = GetSpawnPosition();
        snow.Play();
    }

    private void LateUpdate()
    {
        if (targetCamera == null) targetCamera = Camera.main;
        if (targetCamera != null && snow != null)
        {
            Vector3 cameraPosition = targetCamera.transform.position;
            snow.transform.position = new Vector3(cameraPosition.x, cameraPosition.y + 10f, cameraPosition.z);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        if (targetCamera == null) targetCamera = Camera.main;
        if (targetCamera != null)
        {
            Vector3 p = targetCamera.transform.position;
            return new Vector3(p.x, p.y + 10f, p.z);
        }
        return new Vector3(0f, 10f, 0f);
    }
}
