using Part15;
using Part15.Decoration;

namespace Part15_UnitTest_FindConsoleApp
{
    public class FindTextInManyFile
    {
        [InlineData(Constants.FindTextWithVandCManyFile.Input1)]
        [InlineData(Constants.FindTextWithVandCManyFile.Input2)]
        [InlineData(Constants.FindTextWithVandCManyFile.Input3)]
        [InlineData(Constants.FindTextWithVandCManyFile.Input4)]
        [InlineData(Constants.FindTextWithVandCManyFile.Input5)]
        [InlineData(Constants.FindTextWithVandCManyFile.Input7)]
        [InlineData(Constants.FindTextWithVandCManyFile.Input8)]
        [InlineData(Constants.FindTextWithVandCManyFile.Input9)]
        [InlineData(Constants.FindTextWithVandCManyFile.Input10)]
        [InlineData(Constants.FindTextWithVandCManyFile.Input11)]
        [InlineData(Constants.FindTextWithVandCManyFile.Input12)]
        [Theory]
        public void TestFindTextWithVandCManyFile(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithVandCManyFile.Output;

            foreach (var item in listInput)
            {
              var results =  findWindow.ProduceResult(item, new FakeForTestingComponent());
              Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input1)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input2)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input3)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input4)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input5)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input7)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input8)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input9)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input10)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input11)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input12)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input13)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input14)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input15)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input16)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input17)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input18)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input19)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input20)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input21)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input22)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input23)]
        [InlineData(Constants.FindTextWithCandNOrOnlyCManyFiles.Input24)]
        [Theory]
        public void TestFindTextWithC(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithCandNOrOnlyCManyFiles.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithVManyFiles.Input1)]
        [InlineData(Constants.FindTextWithVManyFiles.Input2)]
        [InlineData(Constants.FindTextWithVManyFiles.Input3)]
        [InlineData(Constants.FindTextWithVManyFiles.Input4)]
        [InlineData(Constants.FindTextWithVManyFiles.Input5)]
        [InlineData(Constants.FindTextWithVManyFiles.Input6)]
        [InlineData(Constants.FindTextWithVManyFiles.Input7)]
        [InlineData(Constants.FindTextWithVManyFiles.Input8)]
        [InlineData(Constants.FindTextWithVManyFiles.Input9)]
        [InlineData(Constants.FindTextWithVManyFiles.Input10)]
        [InlineData(Constants.FindTextWithVManyFiles.Input11)]
        [InlineData(Constants.FindTextWithVManyFiles.Input12)]
        [Theory]
        public void TestFindTextWithVManyFiles(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithVManyFiles.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithNManyFiles.Input1)]
        [InlineData(Constants.FindTextWithNManyFiles.Input2)]
        [InlineData(Constants.FindTextWithNManyFiles.Input3)]
        [InlineData(Constants.FindTextWithNManyFiles.Input4)]
        [InlineData(Constants.FindTextWithNManyFiles.Input5)]
        [InlineData(Constants.FindTextWithNManyFiles.Input6)]
        [InlineData(Constants.FindTextWithNManyFiles.Input7)]
        [InlineData(Constants.FindTextWithNManyFiles.Input8)]
        [InlineData(Constants.FindTextWithNManyFiles.Input9)]
        [InlineData(Constants.FindTextWithNManyFiles.Input10)]
        [InlineData(Constants.FindTextWithNManyFiles.Input11)]
        [InlineData(Constants.FindTextWithNManyFiles.Input12)]
        [Theory]
        public void TestFindTextWithNManyFiles(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithNManyFiles.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithIManyFiles.Input1)]
        [InlineData(Constants.FindTextWithIManyFiles.Input2)]
        [InlineData(Constants.FindTextWithIManyFiles.Input3)]
        [InlineData(Constants.FindTextWithIManyFiles.Input4)]
        [InlineData(Constants.FindTextWithIManyFiles.Input5)]
        [InlineData(Constants.FindTextWithIManyFiles.Input6)]
        [InlineData(Constants.FindTextWithIManyFiles.Input7)]
        [InlineData(Constants.FindTextWithIManyFiles.Input8)]
        [InlineData(Constants.FindTextWithIManyFiles.Input9)]
        [InlineData(Constants.FindTextWithIManyFiles.Input10)]
        [InlineData(Constants.FindTextWithIManyFiles.Input11)]
        [InlineData(Constants.FindTextWithIManyFiles.Input12)]
        [Theory]
        public void TestFindTextWithIManyFiles(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithIManyFiles.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }

        [InlineData(Constants.FindTextWithDefaultManyFiles.Input1)]
        [InlineData(Constants.FindTextWithDefaultManyFiles.Input2)]
        [InlineData(Constants.FindTextWithDefaultManyFiles.Input3)]
        [InlineData(Constants.FindTextWithDefaultManyFiles.Input4)]
        [Theory]
        public void TestFindTextWithDefaultManyFiles(string inputs)
        {
            // Arrange
            string[] listInput = new string[] { inputs };

            //Act
            FindWindow findWindow = new FindWindow();

            //Assert
            var output = Constants.FindTextWithDefaultManyFiles.Output;

            foreach (var item in listInput)
            {
                var results = findWindow.ProduceResult(item, new FakeForTestingComponent());
                Assert.Equal(output, results);
            }
        }

    }
}