//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Archive.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class DocumentNarratorRelation
    {
        public int DocumentNarratorRelationId { get; set; }
        public Nullable<int> DocumentId { get; set; }
        public Nullable<int> NarratorId { get; set; }
    
        public virtual Narrator Narrator { get; set; }
        public virtual Document Document { get; set; }
    }
}
