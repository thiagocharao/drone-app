using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DroneApp.Lib;
using NUnit.Framework;
using Moq;


namespace DroneApp.UnitTests
{
    [TestFixture]
    public class DroneTests
    {
		private Mock<IPosition> _position = null;
        private IDrone _drone = null;

        [SetUp]
        public void Setup()
        {
            _position = new Mock<IPosition>();
        }

        private void SetupDrone()
        {
			_position.SetupProperty(x => x.X, 0);
            _position.SetupProperty(x => x.Y, 0);
			_drone = new Drone(_position.Object);
        }

        [Test]
        public void Move_Drone_1()
        {
            SetupDrone();
		
			_drone.Go("NNNLLL");

            //Assert
            Console.WriteLine(_drone.ToString());
			Assert.AreEqual(_drone.Position.X,3);
			Assert.AreEqual(_drone.Position.Y,3);
        }

		[Test]
		public void Move_Drone_2()
		{
			SetupDrone();

			_drone.Go("NLNLNL");

			//Assert
			Console.WriteLine(_drone.ToString());
			Assert.AreEqual(_drone.Position.X,3);
			Assert.AreEqual(_drone.Position.Y,3);
		}

		[Test]
		public void Move_Drone_3()
		{
			SetupDrone();

			_drone.Go("NNNXLLLXX");

			//Assert
			Console.WriteLine(_drone.ToString());
			Assert.AreEqual(_drone.Position.X,1);
			Assert.AreEqual(_drone.Position.Y,2);
		}

		[Test]
		public void Move_Drone_4()
		{
			SetupDrone();

			_drone.Go("N123LSX");

			//Assert
			Console.WriteLine(_drone.ToString());
			Assert.AreEqual(_drone.Position.X,1);
			Assert.AreEqual(_drone.Position.Y,123);
		}

    }
}
