//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BooksAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sales
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DateOfSale { get; set; }
        public string Price { get; set; }
        public Nullable<int> Id_Book { get; set; }
    
        public virtual Books Books { get; set; }
    }
}
