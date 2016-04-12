﻿namespace Sitecore.Foundation.Installer.Tests
{
  using System.Collections.Generic;
  using NSubstitute;
  using Sitecore.Foundation.Installer.XmlTransform;
  using Xunit;

  public class PostStepTests
  {
    [Theory]
    [AutoSububstituteData]
    public void RunShouldCallXdtTransform(IXdtTransformEngine xdt, IFilePathResolver path, ITransformsProvider transform)
    {
      var postStep = new PostStep(xdt, path, transform);
      transform.GetTransformsByLayer(Arg.Any<string>()).Returns(new List<string>() {"web.config.transform"});

      //act
      postStep.Run(null, null);
      xdt.Received().ApplyConfigTransformation(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
    }


    [Theory]
    [AutoSububstituteData]
    public void RunShouldNotCallXdtTransformIfTransformFileIsMissing(IXdtTransformEngine xdt, IFilePathResolver path, ITransformsProvider transform)
    {
      path.MapPath(Arg.Any<string>()).Returns((string)null);
      transform.GetTransformsByLayer(Arg.Any<string>()).Returns(new List<string>());
      var postStep = new PostStep(xdt, path, transform);

      //act
      postStep.Run(null, null);
      xdt.DidNotReceive().ApplyConfigTransformation(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
    }

  }
}