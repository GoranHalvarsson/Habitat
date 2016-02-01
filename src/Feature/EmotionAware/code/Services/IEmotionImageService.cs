namespace VisionsInCode.Foundation.EmotionAware.Services
{
  using System.Threading.Tasks;
  using VisionsInCode.Foundation.ProjectOxfordAI.Enums;

  public interface IEmotionImageService
  {
    Task<Emotions> GetEmotionFromImage(string stringBase64Image);
  }
}