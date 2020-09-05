using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Burst;
using UnityEngine;

public class ExampleJob : MonoBehaviour
{
    [SerializeField] int mJobCount = 10;
    [SerializeField] int mRepetitions = 10000;
    [SerializeField] float delta = 0.0f;

    void Update()
    {
        float timer = Time.realtimeSinceStartup;
        NativeList<JobHandle> jobList = new NativeList<JobHandle>(Allocator.Temp);
        for (int i = 0; i < mJobCount; i++)
        {
            JobHandle tempJob = ComplexJobHandle();            
            jobList.Add(tempJob);
        }
        JobHandle.CompleteAll(jobList);
        jobList.Dispose();
        
        delta = ((Time.realtimeSinceStartup - timer) * 1000f);
    }
    JobHandle ComplexJobHandle()
    {
        ComplexJob tempJob = new ComplexJob();
        tempJob.repetitions = mRepetitions;
        return tempJob.Schedule();
    }
    [BurstCompile]
    public struct ComplexJob : IJob
    {
        public int repetitions;

        public void Execute()
        {
            float value = 0.0f;
            for (int i = 0; i < repetitions; i++)
            {
                value = Mathf.Pow(i, 2);
            }
        }
    }
}
