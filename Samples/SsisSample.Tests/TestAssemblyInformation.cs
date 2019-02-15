using System;
using System.Collections.Generic;

namespace LegiTestProject1
{
    public static class TestAssemblyInformation
    {
        public static int AssemblyTestCount { get { return 2; } }
    
        public static IDictionary<Guid, int> SuiteTestCounts
        {
            get
            {
                return new Dictionary<Guid, int>
                {
                    { new Guid("{16db26af-28f6-4959-ace5-786b48a985d4}"), 1 },
                    { new Guid("{6b801d75-7762-4065-818d-4bd461ca90d0}"), 1 },
                };
            }
        }
    }
}
