using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Task1.CancellationTokens;

internal static class Calculator
{
    // todo: change this method to support cancellation token
    public async static Task<long> Calculate(int n, CancellationToken token)
    {
        long sum = 0;
        //to be able to cance; the operaton
        await Task.Delay(2000);

        for (var i = 0; i < n; i++)
        {
            if (token.IsCancellationRequested)
            {
                break;
            }
            // i + 1 is to allow 2147483647 (Max(Int32)) 
            sum = sum + (i + 1);
            await Task.Delay(10);
        }
        return sum;
    }
}
