using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StoryGenerator.Controllers;
using StoryGenerator.Domain;
using StoryGenerator.Domain.Validation.Candidates;
using StoryGenerator.Persistance.Abstractions;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Text;
using StoryGenerator.Domain.Validation;

namespace Tests.ControllerTests
{
    [TestFixture]
    public class ServantControllerTests
    {
        Mock<IServantRepository> MockRepo;
        Mock<IValidator<CreationCandidate<Servant>>> MockServantCreationValidator;

        [SetUp]
        protected void SetUp()
        {
            MockRepo = new Mock<IServantRepository>();
            MockServantCreationValidator = new Mock<IValidator<CreationCandidate<Servant>>>();
        }

        [Test]
        public void GetServantById_ShouldReturnNoContentResult_WhenServantIsNull()
        {
            var id = 1;

            MockRepo.Setup(repo => repo.GetServantById(id)).Returns<int>(sId => null);

            var controller = new ServantController(MockRepo.Object, MockServantCreationValidator.Object);

            Assert.IsInstanceOf<NoContentResult>(controller.GetServantById(id));
        }

        [Test]
        public void GetServant_ShouldReturnServant_WhenServantIsFoundInRepository()
        {
            var id = 1;

            MockRepo.Setup(repo => repo.GetServantById(id)).Returns<int>(m => new Servant());

            var controller = new ServantController(MockRepo.Object, MockServantCreationValidator.Object);

            Assert.IsInstanceOf<Servant>(controller.GetServantById(id));
        }

        [Test]
        public void SaveServant_ShouldReturnOkResult_WhenTheServantIsValid()
        {
            var servant = new Servant();

            MockRepo.Setup(repo => repo.SaveServant(servant)).Verifiable();
            MockServantCreationValidator.Setup(mscv => mscv.Validate(It.IsAny<CreationCandidate<Servant>>())).Returns(new ValidationResult());

            var controller = new ServantController(MockRepo.Object, MockServantCreationValidator.Object);

            Assert.IsInstanceOf<OkObjectResult>(controller.SaveServant(servant));
        }

        [Test]
        public void SaveServant_ShouldReturnErrors_WhenTheServantIsInvalid()
        {
            var servant = new Servant();
            servant.Strength = 1000;

            MockRepo.Setup(repo => repo.SaveServant(servant)).Verifiable();
            var realServantCreationValidator = new ServantCreationValidator();

            var controller = new ServantController(MockRepo.Object, realServantCreationValidator);

            Assert.IsInstanceOf<IList<ValidationFailure>>(controller.SaveServant(servant));
        }
    }
}
