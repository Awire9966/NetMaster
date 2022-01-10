using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NetMaster
{
    public class NetCompiler
    {
        public void compile(string code, string reffolder, string outputpath, string outputname, bool runexecutable, CompilerCodeType compilerCodeType, CodeExceptionHandler typeofexception, ExecutableType type)
        {
            if (compilerCodeType == CompilerCodeType.Csharp)
            {
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                ICodeCompiler icc = codeProvider.CreateCompiler();
                string Output = outputpath + @"\" + outputname;

               

                System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
                
                if (type == ExecutableType.ExeFile)
                {
                    parameters.GenerateExecutable = true;
                }
                if (type == ExecutableType.DLLFile)
                {
                    parameters.GenerateExecutable = false;
                }
                parameters.OutputAssembly = Output;

                string[] fileEntries = Directory.GetFiles(reffolder);
                foreach (string fileName in fileEntries)
                {
                    parameters.ReferencedAssemblies.Add(fileName);
                }
                CompilerResults results = icc.CompileAssemblyFromSource(parameters, code);

                if (results.Errors.Count > 0)
                {

                    foreach (CompilerError CompErr in results.Errors)
                    {
                        if (typeofexception == CodeExceptionHandler.Console)
                        {
                            Console.WriteLine(CompErr.ErrorText);
                        }
                        if (typeofexception == CodeExceptionHandler.Exception)
                        {
                            throw new Exception(CompErr.ErrorText);
                        }
                        if (typeofexception == CodeExceptionHandler.MessageBox)
                        {
                            MessageBox.Show(CompErr.ErrorText, "Errors in your code: ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                          
                        }
                     

                    }
                }
                else
                {

                    return;
                }
                if (compilerCodeType == CompilerCodeType.VBScript)
                {
                    VBCodeProvider vbcodeProvider = new VBCodeProvider();
                    ICodeCompiler vbicc = vbcodeProvider.CreateCompiler();
                    string vbOutput = outputpath + @"\" + outputname;



                    System.CodeDom.Compiler.CompilerParameters vbparameters = new CompilerParameters();

                    if (type == ExecutableType.ExeFile)
                    {
                        vbparameters.GenerateExecutable = true;
                    }
                    if (type == ExecutableType.DLLFile)
                    {
                        vbparameters.GenerateExecutable = false;
                    }
                    parameters.OutputAssembly = Output;

                    string[] vbfileEntriess = Directory.GetFiles(reffolder);
                    foreach (string fileName in vbfileEntriess)
                    {
                        parameters.ReferencedAssemblies.Add(fileName);
                    }
                    CompilerResults vbresults = icc.CompileAssemblyFromSource(parameters, code);

                    if (vbresults.Errors.Count > 0)
                    {

                        foreach (CompilerError CompErr in vbresults.Errors)
                        {
                            if (typeofexception == CodeExceptionHandler.Console)
                            {
                                Console.WriteLine(CompErr.ErrorText);
                            }
                            if (typeofexception == CodeExceptionHandler.Exception)
                            {
                                throw new Exception(CompErr.ErrorText);
                            }
                            if (typeofexception == CodeExceptionHandler.MessageBox)
                            {
                                MessageBox.Show(CompErr.ErrorText, "Errors in your code: ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                            }


                        }
                    }
                    else
                    {

                        return;
                    }
                }
            }
        }
    
    }


}
