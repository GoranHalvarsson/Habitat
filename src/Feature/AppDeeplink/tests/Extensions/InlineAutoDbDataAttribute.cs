namespace VisionsInCode.Feature.AppDeeplink.Tests.Extensions
{
  using Ploeh.AutoFixture.Xunit2;


  public class InlineAutoDbDataAttribute : InlineAutoDataAttribute
  {
    public InlineAutoDbDataAttribute(params object[] values)
      : base(new AutoDbDataAttribute(), values)
    {
    }
  }
}