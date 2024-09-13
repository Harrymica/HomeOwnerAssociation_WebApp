using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class FinancialManagement
    {
        public int Id { get; set; }
       
        public string? Financialreports { get; set; }

        public List<MaintenanceHistory> MaintenanceHistory { get; set; }  
       // public int MaintenanceHistoryId { get; set; }

        public List<Budgeting> Budgeting { get; set; }
       // public int BudgetingId { get; set; }

        public List<BankAccount> BankAccounts { get; set; } 
       // public int BankAccountId { get; set; }

        public List<Fee> Fees { get; set; }
       // public int FeeId { get; set; }    

        public List<ExeptionalBudgeting> ExeptionalBudgetings { get; set; }   
        public int ExeptionalBudgetingsId { get; set; }

       


    }
}
