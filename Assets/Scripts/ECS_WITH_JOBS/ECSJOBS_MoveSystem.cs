using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Jobs;
using Unity.Collections;

public class ECSJOBS_MoveSystem : JobComponentSystem
{
    [BurstCompile]
    private struct MoveJob : IJobForEach<Translation, ECSJOBS_MoveComponent>
    {
        public void Execute(ref Translation translation, ref ECSJOBS_MoveComponent moveComponent)
        {
            translation.Value.y += moveComponent.movementSpeed * moveComponent.time;
            translation.Value.x += moveComponent.movementSpeed * moveComponent.time;

            // If Y is within bounds, flip speed - reversing travel
            if (translation.Value.y > 5f)
            {
                moveComponent.movementSpeed = -math.abs(moveComponent.movementSpeed);
            }

            // If Y is within bounds, flip speed - reversing travel
            if (translation.Value.y < -5f)
            {
                moveComponent.movementSpeed = +math.abs(moveComponent.movementSpeed);
            }
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var jobHandle = new MoveJob { };
        jobHandle.Schedule(this, inputDeps).Complete();

        return inputDeps;
    }
}
