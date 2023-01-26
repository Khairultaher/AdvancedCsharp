using Polly;


void CallParallelFor()
{
    Parallel.For(0, 10, i => {
        Console.WriteLine("Thread {0} processing value {1}", Thread.CurrentThread.ManagedThreadId, i);
    });
}

void CallParallelForEach()
{
    List<string> values = new List<string> { "value1", "value2", "value3" };
    Parallel.ForEach(values, value => {
        Console.WriteLine("Thread {0} processing value {1}", Thread.CurrentThread.ManagedThreadId, value);
    });

}

async Task CallParallelForEachWithOption()
{
    List<string> values = new List<string> { "value1", "value2", "value3", "value4", "value5", "value6", "value7" };
    ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = 5 };
    await Parallel.ForEachAsync(values, options, async (value, cancellationToken) => {
        await Task.Delay(3000);
        Console.WriteLine("Thread {0} processing value {1}", Thread.CurrentThread.ManagedThreadId, value);
    });
}


await ParallelForEachWithRetryPolicy();
async Task ParallelForEachWithRetryPolicy()
{
    List<string> values = new List<string> { "value1", "value2", "value3", "value4", "value5", "value6", "value7" };
    var retryPolicy = Policy
        .Handle<Exception>()
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

    ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = 3 };
    await Parallel.ForEachAsync(values, options, async (value, CancellationToken) => {
        await retryPolicy.ExecuteAsync(async () => {
            await DoSomethingAsync(value);
        });
    });

}

static async Task DoSomethingAsync(string value)
{
    await Task.Delay(1000);
    Console.WriteLine("Thread {0} processing value {1}", Thread.CurrentThread.ManagedThreadId, value);
}





