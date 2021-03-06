using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System;
using System.Text;
using System.Globalization;
// <copyright file="PexAssemblyInfo.cs">Copyright ©  2018</copyright>
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("EmailSendServiceDLL")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]
[assembly: PexInstrumentType(typeof(TextInfo))]
[assembly: PexInstrumentType(typeof(EncodingProvider))]
[assembly: PexInstrumentType("mscorlib", "System.Globalization.EncodingTable")]
[assembly: PexInstrumentAssembly("System.Configuration")]
[assembly: PexInstrumentType(typeof(Enum))]
[assembly: PexInstrumentType(typeof(IdnMapping))]
[assembly: PexInstrumentType(typeof(TimeZoneInfo))]
[assembly: PexInstrumentType(typeof(TextInfo))]
[assembly: PexInstrumentAssembly("System")]
[assembly: PexInstrumentType(typeof(SafeHandleZeroOrMinusOneIsInvalid))]
[assembly: PexInstrumentType(typeof(SafeHandle))]
[assembly: PexInstrumentType(typeof(Marshal))]
[assembly: PexInstrumentType(typeof(GCHandle))]
[assembly: PexInstrumentType(typeof(SafeHandleMinusOneIsInvalid))]

