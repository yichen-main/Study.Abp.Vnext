namespace Frame.EntityFrameworkCore.Tests;

//把 FrameEntityFrameworkCoreTestModule 模塊傳送到 NovelTestBase 基礎類(每個測試用例都要繼承這個類才能使用方法)
public abstract class FrameEntityFrameworkCoreTestBase : NovelTestBase<FrameEntityFrameworkCoreTestModule>
{

}