using Cathei.BakingSheet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_CSV
{
    public class ConfigBossSkillSheet : Sheet<ConfigBossSkillSheet.Row>
    {
        public class Row : SheetRow
        {
            // use name of matching column
            public string IdLog { get; private set; }
            public string SkillName { get; private set; }
            public string BuffName { get; private set; }
            public int SkillChance{ get; private set; }
            public float Value1{ get; private set; }
            public float Value2{ get; private set; }
            public float Value3{ get; private set; }
            public float Value4{ get; private set; }
            public float Value5{ get; private set; }

            public string ToJSON()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}
