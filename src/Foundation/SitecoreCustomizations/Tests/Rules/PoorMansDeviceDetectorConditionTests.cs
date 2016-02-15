namespace VisionsInCode.Foundation.SitecoreCustomizations.Tests.Rules
{
  using FluentAssertions;
  using Sitecore.FakeDb;
  using Sitecore.Rules;
  using VisionsInCode.Foundation.SitecoreCustomizations.Rules;
  using VisionsInCode.Foundation.SitecoreCustomizations.Tests.Extensions;
  using Xunit;

  public class PoorMansDeviceDetectorConditionTests
  {
   
    private void SetupDb(Db database)
    {
      database.Add(new DbItem("Settings")
      {
        ParentID = Sitecore.ItemIDs.SystemRoot,
        Children =
        {
          new Sitecore.FakeDb.DbItem("Rules")
          {
            new Sitecore.FakeDb.DbItem("Definitions")
            {
              new Sitecore.FakeDb.DbItem("String Operators")
              {
                new Sitecore.FakeDb.DbItem(Constants.StringOperations.Contains.ItemName, Constants.StringOperations.Contains.ItemID)

              }
            }
          }
        }

      });
    }

    [Theory]
    [InlineAutoDbData("Mozilla/5.0 (iPhone; CPU iPhone OS 8_0 like Mac OS X) AppleWebKit/600.1.3 (KHTML, like Gecko) Version/8.0 Mobile/12A4345d Safari/600.1.4", "iPhone", true)]
    public void DoesUserAgentContainValueCondition(string userAgent, string containsUserAgentValue, bool expectedResult, Db database)
    {


      SetupDb(database);


      RuleContext ruleContext = new RuleContext();

      PoorMansDeviceDetectorCondition<RuleContext> customUserAgentCondition = new PoorMansDeviceDetectorCondition<RuleContext>()
      {
        OperatorId = Constants.StringOperations.Contains.ItemID.ToString(),
        Value = containsUserAgentValue,
        UserAgent = userAgent
      };

      var ruleStack = new RuleStack();

      // act
      customUserAgentCondition.Evaluate(ruleContext, ruleStack);

      // assert
      ruleStack.Should().HaveCount(1);

      object value = ruleStack.Pop();

      value.Should().Be(expectedResult);




    }
  }
}