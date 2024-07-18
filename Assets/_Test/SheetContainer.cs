using Cathei.BakingSheet;
using Cathei.BakingSheet.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_CSV
{
    public class SheetContainer : SheetContainerBase
    {
        public SheetContainer() : base(UnityLogger.Default) { }

        // property name matches with corresponding sheet name
        // for .xlsx or google sheet, it is name of the sheet tab in the workbook
        // for .csv or .json, it is name of the file

        // add other sheets as you extend your project
        //public CharacterSheet Characters { get; private set; }
        public MasterProductConfigSheet MasterProductConfigSheet { get; private set; }
    }
}
