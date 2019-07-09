using System;
using System.Collections.Generic;

namespace SsasTabularSample.Tests
{
    public static class TestAssemblyInformation
    {
        public static int AssemblyTestCount { get { return 1; } }
    
        public static IDictionary<Guid, int> SuiteTestCounts
        {
            get
            {
                return new Dictionary<Guid, int>
                {
                    { new Guid("{163617d2-c58d-47a6-8835-2ae96adde9f2}"), 1 },
                };
            }
        }
    }
}
