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
    
    public partial class Depot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Depot()
        {
            this.Staff = new HashSet<Staff>();
            this.VanTrain = new HashSet<VanTrain>();
        }
    
        public int IdDepot { get; set; }
        public string NameDepot { get; set; }
        public int IdMetroLine { get; set; }
    
        public virtual MetroLine MetroLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VanTrain> VanTrain { get; set; }
    }
}