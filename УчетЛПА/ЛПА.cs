//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace УчетЛПА
{
    using System;
    using System.Collections.Generic;
    
    public partial class ЛПА
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ЛПА()
        {
            this.Ознакомление = new HashSet<Ознакомление>();
        }
    
        public int ID { get; set; }
        public string Наимемнование { get; set; }
        public System.DateTime Дата_введения { get; set; }
        public System.DateTime Дата_обновления { get; set; }
        public System.DateTime Срок_контроля { get; set; }
        public int id_отдела { get; set; }
    
        public virtual Отдел Отдел { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ознакомление> Ознакомление { get; set; }
    }
}
