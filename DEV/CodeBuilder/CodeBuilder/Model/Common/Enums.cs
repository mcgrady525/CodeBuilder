using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CodeBuilder.Model.Common
{
    /// <summary>
    /// 生成类型
    /// </summary>
    [Serializable]
    public enum GenerateType : byte
    {
        [Description("单表生成")]
        SingleTable= 1,

        [Description("批量生成")]
        MultiTable= 2
    }

    /// <summary>
    /// 代码类型
    /// </summary>
    [Serializable]
    public enum CodeType : byte
    {
        [Description("数据库实体")]
        POCOEntity = 1,

        [Description("DAL")]
        DAL = 2,

        [Description("Service")]
        Service= 3,

        [Description("DO")]
        DOEntity = 4
    }


}
