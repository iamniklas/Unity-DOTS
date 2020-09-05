using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct RotationComponent : IComponentData
{
    public float3 rotationVector;
    public float rotationSpeed;
}
