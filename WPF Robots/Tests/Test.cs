using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Robots.Models;
using WPF_Robots.ViewModels;
using Xunit.Sdk;

namespace WPF_Robots.Tests
{
    [TestClass]
    public class RobotViewModelTests
    {
        [TestMethod]
        public void TestLoadRobots()
        {
            // Arrange
            var viewModel = new RobotViewModel();

            // Act
            viewModel.LoadRobotsCommand.Execute(null);

            // Assert
            Assert.IsTrue(viewModel.Robots.Count > 0);
        }

        [TestMethod]
        public void TestUpdateRobot()
        {
            // Arrange
            var viewModel = new RobotViewModel();
            var robot = new Robot { Id = 1, Name = "TestRobot", Status = "Active", BatteryLevel = 50 };

            // Act
            viewModel.UpdateRobotCommand.Execute(robot);

            // Assert
            Assert.AreEqual("Inactive", robot.Status);
            Assert.AreEqual(51, robot.BatteryLevel);
        }
    }

}
