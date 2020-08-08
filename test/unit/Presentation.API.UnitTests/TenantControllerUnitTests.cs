using System;
using Xunit;
using Moq;
using Presentation.API.Controllers;
using Microsoft.Extensions.Logging;
using Presentation.API.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Presentation.API.UnitTests
{
    public class TenantControllerUnitTests
    {
        [Fact]
        public void Get_NoFiltersRequest_OKResult()
        {
            //Arrange
            var logger = Mock.Of<ILogger<TenantController>>();
            var controller = new TenantController(logger);

            //Act
            var actionResult = controller.Get();
            //Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var modelResult = result.Value as IEnumerable<TenantViewModel>;
            Assert.NotNull(modelResult);
        }
    }
}
