using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Enzyme
{
    /// <summary>
    /// 以系统异常为参数的异常处理委托
    /// </summary>
    /// <param name="Ex"></param>
    public delegate void ExceptionHandler(Exception Ex);
}
