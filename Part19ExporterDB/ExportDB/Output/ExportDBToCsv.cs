
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections;
using System.Globalization;
using System.IO.Compression;

namespace Part19ExportDB.Output
{
    public class ExportDBToCsv : IExportDB
    {

        public void Export(string nameFile, IEnumerable<dynamic> datas, bool isZipped = false)
        {
            Console.WriteLine($"Start To Exporting {nameFile} to CSV");

            var outputFolder = CreateExportFolder(nameFile);

            var outputFileName = Path.Combine(outputFolder, nameFile + ".csv");

            var pathFileToZip = WriteToCsv(outputFileName, datas);

            if (isZipped)
            {
                ZipFile(pathFileToZip, nameFile);
            }

            Console.WriteLine($"Complete To Exporting {nameFile} to CSV");
        }

        private static string CreateExportFolder(string nameFile)
        {
            // check if export folder is existed. If not create
            var exportPath = Path.Combine(Directory.GetCurrentDirectory(), "exports");
            if (!Directory.Exists(exportPath))
            {
                Console.WriteLine($"Creating {exportPath}");
                Directory.CreateDirectory(exportPath);
            }
            return exportPath;
        }

        private string WriteToCsv(string nameFile, IEnumerable<dynamic> datas)
        {
            using StreamWriter output = File.CreateText(nameFile);
            using var csvWriter = new CsvWriter(output, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(datas);

            return nameFile;
        }

        private void ZipFile(string csvFilePath, string nameFile)
        {
            var roothPath = new DirectoryInfo(csvFilePath).Parent?.FullName;
            Console.WriteLine($"Root data path is {roothPath ?? throw new NullReferenceException(nameof(roothPath))}");
            string zipFilePath = Path.Combine(roothPath, nameFile + ".zip");

            try
            {
                using (FileStream zipToCreate = new FileStream(zipFilePath, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                    {
                        string fileName = Path.GetFileName(csvFilePath);
                        ZipArchiveEntry zipEntry = archive.CreateEntry(fileName);

                        using (StreamWriter writer = new StreamWriter(zipEntry.Open()))
                        {
                            writer.Write(File.ReadAllText(csvFilePath));
                        }
                    }
                }

                Console.WriteLine($"CSV file successfully zipped to {zipFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}