using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct CalcWithFibbonaciJob : IJob
{
    private int divisor;
    private NativeArray<int> nativeArray;

    public CalcWithFibbonaciJob(int div, ref NativeArray<int> arr){
        divisor = div;
        nativeArray = arr;
    }
    public void Execute()
    {
        for(int i =0; i< nativeArray.Length; i++){

            nativeArray[i] = nativeArray[i]/ divisor;
        }
    }


}
