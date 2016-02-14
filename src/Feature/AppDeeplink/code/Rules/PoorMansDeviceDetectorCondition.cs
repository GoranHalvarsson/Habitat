namespace VisionsInCode.Feature.AppDeeplink.Rules
{

  using System.Web;
  using Sitecore.Diagnostics;
  using Sitecore.Rules;
  using Sitecore.Rules.Conditions;

  public class PoorMansDeviceDetectorCondition<T> : StringOperatorCondition<T> where T : RuleContext
  {

    public string Value { get; set; }

    /// <summary>
    /// Testable UserAgent
    /// </summary>
    public string UserAgent { get; set; }


    /// <summary>
    /// Executes the specified rule context.
    /// 
    /// </summary>
    /// <param name="ruleContext">The rule context.</param>
    /// <returns>
    /// <c>True</c>, if the condition succeeds, otherwise <c>false</c>.
    /// </returns>
    protected override bool Execute(T ruleContext)
    {
      Assert.ArgumentNotNull(ruleContext, "ruleContext");

      if (string.IsNullOrWhiteSpace(UserAgent))
        this.UserAgent = HttpContext.Current.Request.UserAgent;

      if (string.IsNullOrEmpty(this.Value) || (string.IsNullOrEmpty(this.UserAgent)))
        return false;

      return this.Compare(this.UserAgent, this.Value);
    }

  }

}