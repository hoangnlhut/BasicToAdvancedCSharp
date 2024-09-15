using Part15;
using Part15.Decoration;

namespace Part15_UnitTest_FindConsoleApp
{
    public class FindTextInOneFile
    {
        [InlineData(Constants.FindTextWithVandC.Input1)]
        [InlineData(Constants.FindTextWithVandC.Input2)]
        [InlineData(Constants.FindTextWithVandC.Input3)]
        [InlineData(Constants.FindTextWithVandC.Input4)]
        [InlineData(Constants.FindTextWithVandC.Input5)]
        [InlineData(Constants.FindTextWithVandC.Input6)]
        [Theory]
        public void TestFindTextWithVandC(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithVandC.Output;

            foreach (var item in listInput)
            {
              var results =  findWindow.ProduceResult(item, new FakeForTestingComponent());
              Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithC.Input1)]
        [InlineData(Constants.FindTextWithC.Input2)]
        [InlineData(Constants.FindTextWithC.Input3)]
        [InlineData(Constants.FindTextWithC.Input4)]
        [InlineData(Constants.FindTextWithC.Input5)]
        [InlineData(Constants.FindTextWithC.Input6)]
        [Theory]
        public void TestFindTextWithC(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithC.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithCAndN.Input1)]
        [InlineData(Constants.FindTextWithCAndN.Input2)]
        [InlineData(Constants.FindTextWithCAndN.Input3)]
        [InlineData(Constants.FindTextWithCAndN.Input4)]
        [InlineData(Constants.FindTextWithCAndN.Input5)]
        [InlineData(Constants.FindTextWithCAndN.Input6)]
        [Theory]
        public void TestFindTextWithCAndN(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithCAndN.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithV.Input1)]
        [InlineData(Constants.FindTextWithV.Input2)]
        [InlineData(Constants.FindTextWithV.Input3)]
        [InlineData(Constants.FindTextWithV.Input4)]
        [InlineData(Constants.FindTextWithV.Input5)]
        [InlineData(Constants.FindTextWithV.Input6)]
        [Theory]
        public void TestFindTextWithV(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithV.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithN.Input1)]
        [InlineData(Constants.FindTextWithN.Input2)]
        [InlineData(Constants.FindTextWithN.Input3)]
        [InlineData(Constants.FindTextWithN.Input4)]
        [InlineData(Constants.FindTextWithN.Input5)]
        [InlineData(Constants.FindTextWithN.Input6)]
        [Theory]
        public void TestFindTextWithN(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithN.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithI.Input1)]
        [InlineData(Constants.FindTextWithI.Input2)]
        [InlineData(Constants.FindTextWithI.Input3)]
        [InlineData(Constants.FindTextWithI.Input4)]
        [InlineData(Constants.FindTextWithI.Input5)]
        [InlineData(Constants.FindTextWithI.Input6)]
        [Theory]
        public void TestFindTextWithI(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithI.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithDefault.Input1)]
        [InlineData(Constants.FindTextWithDefault.Input2)]
        [Theory]
        public void TestFindTextWithDefault(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithDefault.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }
    }
}