using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nasa.MarsRover.Tests
{
    [TestClass]
    public class MarsRoverTests
    {
        [TestMethod]
        public void MarsRoverAction_Success1()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
            string result = action.Action();

            Assert.AreEqual("1 3 N\r\n5 1 E", result);
        }

        [TestMethod]
        public void MarsRoverAction_Success2()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "0 0 N", "MMMMM", "3 3 E", "MMLMMLMMLMML");
            string result = action.Action();

            Assert.AreEqual("0 5 N\r\n3 3 E", result);
        }

        #region MarsPlateau
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_MarsPlateau_IsNullOrEmpty_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction(null, "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
            action.Action();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_MarsPlateauX_IsIncorrect_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("Q 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
            action.Action();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_MarsPlateauY_IsIncorrect_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 Q", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
            action.Action();
        }
        #endregion

        #region Robot1Position
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot1Position_IsNullOrEmpty_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", null, "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
            action.Action();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot1PositionX_IsIncorrect_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "Q 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
            action.Action();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot1PositionY_IsIncorrect_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 Q N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
            action.Action();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot1Direction_IsIncorrect_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 2 Q", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
            action.Action();
        }
        #endregion

        #region Robot1Commands
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot1Commands_IsNullOrEmpty_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 2 N", null, "3 3 E", "MMRMMRMRRM");
            action.Action();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot1Commands_IsIncorrect_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 2 Q", "LMRQ", "3 3 E", "MMRMMRMRRM");
            action.Action();
        }
        #endregion

        #region Robot2Position
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot2Position_IsNullOrEmpty_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 2 N", "LMLMLMLMM", null, "MMRMMRMRRM");
            action.Action();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot2PositionX_IsIncorrect_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 2 N", "LMLMLMLMM", "Q 3 E", "MMRMMRMRRM");
            action.Action();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot2PositionY_IsIncorrect_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 2 N", "LMLMLMLMM", "3 Q E", "MMRMMRMRRM");
            action.Action();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot2Direction_IsIncorrect_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 2 N", "LMLMLMLMM", "3 3 Q", "MMRMMRMRRM");
            action.Action();
        }
        #endregion

        #region Robot1Commands
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot2Commands_IsNullOrEmpty_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 2 N", "LMLMLMLMM", "3 3 E", null);
            action.Action();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_When_Robot2Commands_IsIncorrect_Then_ThrowException()
        {
            MarsRoverAction action = new MarsRoverAction("5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRMQ");
            action.Action();
        }
        #endregion
    }
}