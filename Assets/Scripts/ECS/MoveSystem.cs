using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

class MoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, ref MoveComponent moveComponent) =>
        {
            translation.Value.x += moveComponent.speed.x * deltaTime;
            translation.Value.y += moveComponent.speed.y * deltaTime;
            translation.Value.z += moveComponent.speed.z * deltaTime;
        });
    }
}
