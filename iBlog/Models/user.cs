//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace iBlog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public string user_name { get; set; }
        public long user_id { get; set; }
        public int user_permission { get; set; }
    
        public virtual user_login user_login { get; set; }
    }
}
