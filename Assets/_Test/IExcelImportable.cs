using Cathei.BakingSheet;

namespace Test_CSV
{
    public interface IExcelImportable
    {
#if UNITY_EDITOR
        void ImportDataFromExcel(SheetRow sheetRow);
#endif
    }
}
