namespace VisionsInCode.Foundation.ProjectOxfordAI.Services
{
  using System.Collections.Generic;
  using System.IO;
  using System.Threading.Tasks;
  using VisionsInCode.Foundation.ProjectOxfordAI.Enums;

  public interface IEmotionsService
  {
    Task<IDictionary<Emotions, float>> ReadEmotionsFromImageStreamAndGetRankedEmotions(Stream imageStream);

  }
}
