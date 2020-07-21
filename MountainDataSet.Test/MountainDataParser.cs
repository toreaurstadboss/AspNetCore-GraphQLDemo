using OfficeOpenXml;

namespace MountainDataSet.Console
{
    public class MountainDataParser
    {

        public T ParseData<T>()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var mountains = ExcelPackageJsonParser.ReadFromExcel<T>("Fjelltopper_kommuner.xlsx");
            return mountains;
        }

    }
}
