namespace WideWorldImporters.Tests.Database_Output
{
    using System.Collections.Generic;
    
    
    // This file provides a point at which partial methods can be implemented to augment tests.
    // The content of this file is preserved when the test suite is regenerated.
    public partial class Database
    {
        static partial void BeforeTest(string testName, Dictionary<string, object> testResources, ref bool cancel)
        {
            // Print debug information to the console to aid with parameter debugging.
            PragmaticWorks.LegiTest.Runtime.ParameterProvider.PrintDebugInformation(parameterProvider);
        }
    }
}

