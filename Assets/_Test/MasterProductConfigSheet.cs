using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cathei.BakingSheet;

namespace Test_CSV
{
    public class MasterProductConfigSheet : Sheet<MasterProductConfigSheet.Row>
    {
        public class Row : SheetRow
        {
            // use name of matching column
            public int SalePrice { get; private set; }
        }
    }
}
