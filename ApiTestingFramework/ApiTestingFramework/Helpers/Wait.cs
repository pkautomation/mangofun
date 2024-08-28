namespace ApiTestingFramework.Helpers;

public class Wait
{
    public static async Task<bool> Until(Func<Task<bool>> func, int attempts = 5, int interval = 1000)
    {
        bool result = await func.Invoke();

        for (int attempted = 0; attempted <= attempts && result == false; attempted++)
        {
            Thread.Sleep(interval);

            result = await func.Invoke();
        }

        return result;
    }

    public static async Task<bool> Until(Func<Task<bool>> func, int attempts = 5, TimeSpan? retryInterval = null)
    {
        if (retryInterval == null)
        {
            return await Until(func, TimeSpan.FromSeconds(1), attempts);
        }
        else
        {
            return await Until(func, (TimeSpan)retryInterval, attempts);
        }
    }

    public static async Task<bool> Until(Func<Task<bool>> func, TimeSpan retryInterval, int attempts = 5)
    {
        bool flag = false;

        for (int attempted = 0; attempted < attempts && !flag; attempted++)
        {
            flag = await func();
            await Task.Delay(retryInterval);
        }
        return flag;
    }
}
