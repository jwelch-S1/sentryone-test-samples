using System;
using System.Collections.Generic;

namespace WideWorldImporters.Tests
{
    public static class TestAssemblyInformation
    {
        public static int AssemblyTestCount { get { return 12; } }
    
        public static IDictionary<Guid, int> SuiteTestCounts
        {
            get
            {
                return new Dictionary<Guid, int>
                {
                    { new Guid("{5dd051a5-2258-40cf-802f-020b0d134d71}"), 11 },
                    { new Guid("{d5acb37e-d4a5-4223-aac2-4b51eecf7137}"), 1 },
                };
            }
        }
    }
}
