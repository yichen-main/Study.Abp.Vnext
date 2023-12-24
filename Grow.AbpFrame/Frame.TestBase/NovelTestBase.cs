namespace Frame.TestBase;

//所有的單元測試類, 都會直接或間接的派生到這個基礎測試類
public abstract class NovelTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule> where TStartupModule : IAbpModule
{
    protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
    {
        options.UseAutofac();
    }

    /// <summary>
    /// 默認工作單元的測試方法
    /// </summary>
    /// <param name="action">要在工作單元中執行的任務</param>
    /// <returns></returns>
    protected virtual Task WithUnitOfWorkAsync(Func<Task> action)
    {
        return WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), action);
    }

    /// <summary>
    /// 默認工作單元的測試方法(有返回值)
    /// </summary>
    /// <typeparam name="TResult">返回值</typeparam>
    /// <param name="func">要在工作單元中執行的任務</param>
    /// <returns></returns>
    protected virtual Task<TResult> WithUnitOfWorkAsync<TResult>(Func<Task<TResult>> func)
    {
        return WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), func);
    }

    /// <summary>
    /// 工作單元的測試方法(沒有返回值)
    /// </summary>
    /// <param name="options">設置工作單元的選項</param>
    /// <param name="action">要在工作單元中執行的任務</param>
    /// <returns></returns>
    protected virtual async Task WithUnitOfWorkAsync(AbpUnitOfWorkOptions options, Func<Task> action)
    {
        using var scope = ServiceProvider.CreateAsyncScope();
        var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
        using var uow = uowManager.Begin(options);

        //放入想執行的任務 
        await action();

        //執行
        await uow.CompleteAsync();
    }

    /// <summary>
    /// 工作單元的測試方法(有返回值)
    /// </summary>
    /// <typeparam name="TResult">返回值</typeparam>
    /// <param name="options">設置工作單元的選項</param>
    /// <param name="func">要在工作單元中執行的任務</param>
    /// <returns></returns>
    protected virtual async Task<TResult> WithUnitOfWorkAsync<TResult>(AbpUnitOfWorkOptions options, Func<Task<TResult>> func)
    {
        using var scope = ServiceProvider.CreateAsyncScope();
        var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
        using var uow = uowManager.Begin(options);

        //放入想執行的任務 
        var result = await func();

        //執行
        await uow.CompleteAsync();
        return result;
    }
}