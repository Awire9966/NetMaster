using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMaster
{
    public enum CompilerCodeType
    {
      Csharp = 1,
     VBScript = 2
    }
    public enum CodeExceptionHandler
    {
        Console = 1,
        Exception = 2,
        MessageBox = 3,
        
    }
    public enum ExecutableType
    {
        ExeFile = 1,
        DLLFile = 2
        
    }
}
