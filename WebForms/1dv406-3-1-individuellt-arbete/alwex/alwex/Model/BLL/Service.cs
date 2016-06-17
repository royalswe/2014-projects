using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using alwex.Model.DAL;
using System.ComponentModel.DataAnnotations;

namespace alwex.Model.BLL
{
    public class Service
    {
        CustomerDAL _CustomerDAL;
        PalletStatementDAL _PalletStatementDAL;
        ReportDAL _ReportDAL;
        private CustomerDAL CustomerDAL
        {
            get { return _CustomerDAL ?? (_CustomerDAL = new CustomerDAL()); }
        }
        private PalletStatementDAL PalletStatementDAL
        {
            get { return _PalletStatementDAL ?? (_PalletStatementDAL = new PalletStatementDAL()); }
        }
        private ReportDAL ReportDAL
        {
            get { return _ReportDAL ?? (_ReportDAL = new ReportDAL()); }
        }
        // Customer delen
        public Customer GetCustomersById(int customerId)
        {
            return CustomerDAL.GetCustomersById(customerId);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return CustomerDAL.GetCustomers();  
        }
        public void DeleteCustomer(int customerid)
        {
            CustomerDAL.DeleteCustomer(customerid);
        }
        public void SaveContact(Customer customer)
        {
            // Validera affärsreglerna 
            var validationContext = new ValidationContext(customer);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(customer, validationContext, validationResults, true))
            {
                var ex = new ValidationException("Kunden kunde inte sparas.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (customer.CustomerID == 0)
            {
                CustomerDAL.InsertCustomer(customer);
            }
            else
            {
                CustomerDAL.UpdateCustomer(customer);
            }
        }
        // PalletStatement delen
        public PalletStatement GetPalletById(int PsID)
        {
            return PalletStatementDAL.GetPalletById(PsID);
        }
        public IEnumerable<PalletStatement> GetPalletStatements(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return PalletStatementDAL.GetPalletStatements(maximumRows, startRowIndex, out totalRowCount);
        }
        public void DeletePalletStatement(int psid)
        {
            PalletStatementDAL.DeletePalletStatement(psid);
        }
        public void SavePalletStatement(PalletStatement palletStatement)
        {
            // Validera affärsreglerna 
            var validationContext = new ValidationContext(palletStatement);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(palletStatement, validationContext, validationResults, true))
            {
                var ex = new ValidationException("Pallstansningen kunde inte sparas.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (palletStatement.PsID == 0)
            {
                PalletStatementDAL.InsertPalletStatement(palletStatement);             
            }
            else
            {
                PalletStatementDAL.UpdatePalletStatement(palletStatement);
            }
        }
        // Report delen
        public IEnumerable<Report> GetReports(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return ReportDAL.GetReports(maximumRows, startRowIndex, out totalRowCount);
        }
    }
}