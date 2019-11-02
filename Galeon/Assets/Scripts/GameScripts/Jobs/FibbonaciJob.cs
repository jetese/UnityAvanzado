using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct FibbonaciJob : IJob
{
    private int n;
    private NativeArray<int> nativeArray;

    public FibbonaciJob(int a_n, ref NativeArray<int> arr){
        n = a_n;
        nativeArray = arr;
    }

    public void Execute()
    {
        int aux, a, b;
        b = 1;
        a = 0;
        for(int i = 0; i<n; ++i){
            aux = a;
            a = b;
            b = aux + a;
            nativeArray[i] = a;
        }
    }
}
