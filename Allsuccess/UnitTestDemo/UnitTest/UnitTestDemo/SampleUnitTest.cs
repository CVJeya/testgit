
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;
using UnitTestApi.Controllers;
using UnitTestApi.Data;
using UnitTestApi.Provider.Contracts;
using Xunit;
using Xunit.Sdk;

namespace UnitTestDemo
{
    public class SampleUnitTest
    {
        private readonly Mock<ILogger<TaskInfoController>> loggerStub = new();

        private readonly Mock<ITaskProvider> providerStub = new();

        private TestContext? testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        [Fact]
        public void GetById_KnownIdPassed_ReturnsFoundResult()
        {
            // Arrange
            var controllerObject = new TaskInfoController(providerStub.Object, loggerStub.Object);
            // Act
            var isFoundResult = controllerObject.GetTask(5);
            System.Console.WriteLine("Output from GetById_KnownIdPassed_ReturnsFoundResult ");
            TestContext.WriteLine("Result from Test Project for the Test Context Instance " + testContextInstance +isFoundResult );
            // Assert
            Xunit.Assert.NotNull(isFoundResult);
        }

        [Fact]
        public void GetById_KnownIdPassed_ReturnsNotFoundResult_Using_Setup()
        {
            // Arrange
         


            // Act
            providerStub.Setup(repo => repo.GetTask(9));

            var controllerObject = new TaskInfoController(providerStub.Object, loggerStub.Object);

            // Assert
            System.Console.WriteLine("Output from GetById_KnownIdPassed_ReturnsFoundResult_Using_Setup ");
            Xunit.Assert.Null(controllerObject.GetTask(9));
        }

        [Fact]
        public void TestEquality()
        {
           // Xunit.Assert.Equal(1, 1);
            System.Console.WriteLine("Output from Test Equality ");
            NUnit.Framework.Assert.Fail("Test");
        }

        [Fact]
        public void AlwaysFail()
        {
            throw new XunitException("Error message.");
        }

        [Xunit.Theory]
        [InlineData(1, "Setting up the Environment for the Project")]
        [InlineData(2, "Designing Front End")]
        [InlineData(17, "Not Found any tasks associated")]
        public void Test_Get_Function_Invoking_Controller(int TaskId, string name)
        {
            /* Instantiating Ilogger object in Unit Testing without Moq package
               var serviceProvider = new ServiceCollection()
                         .AddLogging()
                         .BuildServiceProvider();

             var factory = serviceProvider.GetService<ILoggerFactory>();

             var logger = factory.CreateLogger<TaskInfoController>();  */

            // Writing sample unit tests using moq mocking library

            var controllerObject = new TaskInfoController(providerStub.Object, loggerStub.Object);

            string result = controllerObject.FetchTaskName(TaskId);
            System.Console.WriteLine("Output from Test_Get_Function_Invoking_Controller ");
            Xunit.Assert.Equal(name, result);
        }
       
    }
}
