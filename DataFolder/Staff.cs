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
    
    public partial class Staff
    {
        public int IdStaff { get; set; }
        public string Surname { get; set; }
        public string NameStaff { get; set; }
        public string Patronymic { get; set; }
        public int IdDepot { get; set; }
        public System.DateTime DateOfBitrh { get; set; }
        public byte[] Photo { get; set; }
        public int IdUser { get; set; }
    
        public virtual Depot Depot { get; set; }
        public virtual User User { get; set; }
    }
}
