using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class JobController : MonoBehaviour
{
    private NativeArray<int> result;
    private JobHandle handle;
    private JobHandle secondHandle;
    private bool init = false;
    private int num = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
            //LaunchJob();
            LaunchParallelJob();
        }

        if(init){
            if(secondHandle.IsCompleted){
                init = false;
                secondHandle.Complete();
                
                for (int i = 0; i < num; ++i)
                {
                    Debug.Log(result[i]);
                }
                result.Dispose();
            }
            
        }
    }
    protected void LaunchParallelJob(){
        init = true;
        result = new NativeArray<int>(num, Allocator.Persistent);
        FibbonaciJob fibbonaciJob = new FibbonaciJob(num, ref result);
        CalcFibonacciParallelFor calc = new CalcFibonacciParallelFor(2,ref result);
        handle = fibbonaciJob.Schedule();
        secondHandle = calc.Schedule(num,100,handle);
    }
    protected void LaunchJob(){
        num = 1000;
        result = new NativeArray<int>(num, Allocator.Persistent);
        FibbonaciJob fib = new FibbonaciJob(num, ref result);
        CalcWithFibbonaciJob calc = new CalcWithFibbonaciJob(2, ref result);

        handle = fib.Schedule();
        secondHandle = calc.Schedule(handle);
        init = true;
    }
}
