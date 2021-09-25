using UnityEngine;

public sealed class MovementShapeBehavior : ShapeBehavior
{
    public Vector3 Velocity { get; set; }

    public override ShapeBehaviorType BehaviorType => ShapeBehaviorType.Movement;
    public override void Recycle()
    {
        ShapeBehaviorPool<MovementShapeBehavior>.Reclaim(this);
    }
    public override void GameUpdate(Shape shape)
    {
        shape.transform.localPosition += Velocity * Time.deltaTime;
    }
    public override void Save(GameDataWriter writer)
    { 
        writer.Write(Velocity);
    }
    public override void Load(GameDataReader reader)
    {
        Velocity = reader.ReadVector3();
    }
}
