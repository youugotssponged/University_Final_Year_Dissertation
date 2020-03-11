using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Jobs;
using Unity.Collections;


public class ECSJOBS_MoveSystem : JobComponentSystem
{
    public static JobHandle jh;
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        jh = Entities.ForEach((ref Translation translation, ref ECSJOBS_MoveComponent moveComponent) => {
            // Increase the Translations X & Y by speed and time
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
        }).Schedule(inputDeps);

        return jh;
    }

    public static void Complete()
    {
        NativeList<JobHandle> jobHandles = new NativeList<JobHandle>(Allocator.Temp);
        jobHandles.Add(jh);

        JobHandle.CompleteAll(jobHandles);
    }


}
