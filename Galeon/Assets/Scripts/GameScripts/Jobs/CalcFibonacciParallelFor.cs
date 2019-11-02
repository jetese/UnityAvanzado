using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct CalcFibonacciParallelFor : IJobParallelFor
{
    private int divisor;
    public NativeArray<int> nativeArray;

    public CalcFibonacciParallelFor(int a_d, ref NativeArray<int> arr)
    {
        nativeArray = arr;
        divisor = a_d;
    }
    public void Execute(int index)
    {
        nativeArray[index] = nativeArray[index] / divisor;
    }
}
