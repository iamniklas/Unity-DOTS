using Unity.Transforms;
using Unity.Entities;
using Unity.Mathematics;

public class RotationSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Rotation rotation, ref RotationComponent rotComponent) =>
        {
            rotation.Value = math.mul(rotation.Value, quaternion.RotateX(rotComponent.rotationVector.x
                * math.radians(rotComponent.rotationSpeed * deltaTime)));
            rotation.Value = math.mul(rotation.Value, quaternion.RotateY(rotComponent.rotationVector.y
                * math.radians(rotComponent.rotationSpeed * deltaTime)));
            rotation.Value = math.mul(rotation.Value, quaternion.RotateZ(rotComponent.rotationVector.z
                * math.radians(rotComponent.rotationSpeed * deltaTime)));
        });
    }
}
