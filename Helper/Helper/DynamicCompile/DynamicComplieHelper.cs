
using System.CodeDom.Compiler;
using System.Text;
using Microsoft.CSharp;

namespace Helper.DynamicComplie
{
    public class DynamicComplie
    {
        /// <summary>
        /// 使用動態編譯的時候編譯邏輯判斷
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static object Eval(string expression)
        {
            //创建编译器
            ICodeCompiler comp = new CSharpCodeProvider().CreateCompiler();
            CompilerParameters paramerts = new CompilerParameters();

            //设置源代码
            StringBuilder objBuild = new StringBuilder();
            objBuild.Append("using System; \n");
            objBuild.Append("namespace Aptech.Showlin._temp { \n");
            objBuild.Append("  public class _evalTemp { \n");
            objBuild.Append("    public object _get() ");
            objBuild.Append("{ ");
            objBuild.AppendFormat("      return ({0}); ", expression);
            objBuild.Append("}\n");
            objBuild.Append("} }");

            //动态编译
            CompilerResults cr = comp.CompileAssemblyFromSource(paramerts, objBuild.ToString());

            System.Reflection.Assembly objAss = cr.CompiledAssembly;
            object o = objAss.CreateInstance("Aptech.Showlin._temp._evalTemp");
            System.Reflection.MethodInfo mi = o.GetType().GetMethod("_get");
            return mi.Invoke(o, null);
        }

        /// <summary>
        /// 使用sql方式執行邏輯判斷
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static object EvalSql(string expression)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            System.Data.DataColumn dc = new System.Data.DataColumn("temp", typeof(string), expression);
            dt.Columns.Add(dc);
            dt.Rows.Add(dt.NewRow());
            return dt.Rows[0][0];
        }
    }
}
