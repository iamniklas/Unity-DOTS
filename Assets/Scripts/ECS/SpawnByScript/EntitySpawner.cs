using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] Mesh mMesh = null;
    [SerializeField] Material mMaterial = null;
    [SerializeField] int mTotalObjectsToSpawn = 5;
    
    void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        
        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(MoveComponent),
            typeof(LocalToWorld),
            typeof(RenderMesh),
            typeof(RenderBounds)
            );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(mTotalObjectsToSpawn, Allocator.Temp);

        entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];

            entityManager.SetComponentData(entity,
                new MoveComponent
                {
                    speed = new float3(0, 0, 1)
                }
            );

            entityManager.SetComponentData(entity,
                new Translation
                {
                    Value = new float3(-mTotalObjectsToSpawn + i * (mTotalObjectsToSpawn - 1) / 2, 0, 0)
                }
            );

            entityManager.SetSharedComponentData(entity, 
                new RenderMesh
                {
                    mesh = mMesh,
                    material = mMaterial,
                }
            );
        }
        
        entityArray.Dispose();
    }
}
