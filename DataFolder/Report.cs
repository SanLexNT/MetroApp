//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MetroApp.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int IdReport { get; set; }
        public string TextReport { get; set; }
        public System.DateTime DateOfReport { get; set; }
        public int IdStaff { get; set; }
    
        public virtual Staff Staff { get; set; }
    }
}