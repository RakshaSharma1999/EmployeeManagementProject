//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeManagementProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class LeaveTable
    {
        public int LeaveRequestId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<System.DateTime> LeaveStartDate { get; set; }
        public Nullable<System.DateTime> LeaveEndDate { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ApplyOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateOn { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateOn { get; set; }
    }
}
