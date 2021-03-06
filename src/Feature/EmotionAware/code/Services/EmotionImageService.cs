﻿namespace VisionsInCode.Feature.EmotionAware.Services
{
  using System;
  using System.IO;
  using System.Threading.Tasks;
  using VisionsInCode.Foundation.ProjectOxfordAI.Enums;
  using VisionsInCode.Foundation.ProjectOxfordAI.Services;
  using System.Collections.Generic;
  using System.Linq;

  using Sitecore.Diagnostics;
  using VisionsInCode.Feature.EmotionAware.Models;
  using VisionsInCode.Feature.EmotionAware.Repositories;


    public class EmotionImageService : IEmotionImageService
  {
    private readonly IEmotionAwareSettingsRepository _emotionAwareSettingsRepository;

    private readonly EmotionAwareSettings _emotionAwareSettings;

    public EmotionImageService(IEmotionAwareSettingsRepository emotionAwareSettingsRepository)
    {
      _emotionAwareSettingsRepository = emotionAwareSettingsRepository;
    }

    public EmotionImageService() : this(new EmotionAwareSettingsRepository())
    {
      _emotionAwareSettings = _emotionAwareSettingsRepository.Get();
    }

    public async Task<Emotions> GetEmotionFromImage(string stringBase64Image)
    {

      if (_emotionAwareSettings == null || string.IsNullOrWhiteSpace(_emotionAwareSettings.SubscriptionKey))
      {
        Log.Error("SubscriptionKey is missing for emotion service", typeof(EmotionImageService));
        return Emotions.None;
      }

      IEmotionsService emotionsService = new EmotionsService(_emotionAwareSettings.SubscriptionKey);

      MemoryStream faceImage = new MemoryStream(Convert.FromBase64String(stringBase64Image));

      IDictionary<Emotions, float> emotionRanksResult = await emotionsService.ReadEmotionsFromImageStreamAndGetRankedEmotions(faceImage);

      if (emotionRanksResult == null)
        return Emotions.None;

      return emotionRanksResult.ElementAt(0).Key;

    }



  }


}