using Moq;
using NUnit.Framework;
using StoryGenerator.Controllers;
using StoryGenerator.Domain;
using StoryGenerator.Domain.Validation;
using StoryGenerator.Persistance;
using StoryGenerator.Domain.Validation.Candidates;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using StoryGenerator.Persistance.Abstractions;
using FluentValidation;
using FluentValidation.Results;

namespace Tests.ControllerTests
{
    [TestFixture]
    public class MageControllerTests
    {
        Mock<IMageRepository> MockRepo;
        Mock<IValidator<CreationCandidate<Mage>>> MockMageCreationValidator;

        [SetUp]
        protected void SetUp()
        {
            MockRepo = new Mock<IMageRepository>();
            MockMageCreationValidator = new Mock<IValidator<CreationCandidate<Mage>>>();
        }

        [Test]
        public void GetMage_ShouldReturnNoContentResult_WhenMageIsNull()
        {
            var id = 1;

            MockRepo.Setup(repo => repo.GetMageById(id)).Returns<int>(m => null);

            var controller = new MageController(MockRepo.Object, MockMageCreationValidator.Object);

            Assert.IsInstanceOf<NoContentResult>(controller.GetMage(id));
        }

        [Test]
        public void GetMage_ShouldReturnMage_WhenMageIsFoundInRepository()
        {
            var id = 1;

            MockRepo.Setup(repo => repo.GetMageById(id)).Returns<int>(m => new Mage());

            var controller = new MageController(MockRepo.Object, MockMageCreationValidator.Object);

            Assert.IsInstanceOf<Mage>(controller.GetMage(id));
        }

        [Test]
        public void SaveMage_ShouldReturnOkResult_WhenTheMageIsValid()
        {
            var mage = new Mage();

            MockRepo.Setup(repo => repo.SaveMage(mage)).Verifiable();
            MockMageCreationValidator.Setup(mmcv => mmcv.Validate(It.IsAny<CreationCandidate<Mage>>())).Returns(new ValidationResult());

            var controller = new MageController(MockRepo.Object, MockMageCreationValidator.Object);

            Assert.IsInstanceOf<OkObjectResult>(controller.SaveMage(mage));
        }

        [Test]
        public void SaveMage_ShouldReturnErrors_WhenTheMageIsInvalid()
        {
            var mage = new Mage();
            mage.Strength = 1000;

            MockRepo.Setup(repo => repo.SaveMage(mage)).Verifiable();
            var realMageCreationValidator = new MageCreationValidator();

            var controller = new MageController(MockRepo.Object, realMageCreationValidator);

            Assert.IsInstanceOf<IList<ValidationFailure>>(controller.SaveMage(mage));
        }

    }
}
