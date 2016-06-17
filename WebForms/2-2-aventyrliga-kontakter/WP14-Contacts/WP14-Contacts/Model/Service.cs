using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WP14_Contacts.Model.BLL;
using WP14_Contacts.Model.DAL;

namespace WP14_Contacts.Model
{
    public class Service
    {
        ContactDAL _contactDAL;

        private ContactDAL ContactDAL
        {
            get {return _contactDAL ?? (_contactDAL = new ContactDAL());}
        }
        public void DeleteContact(Contact contact)
        {
            ContactDAL.DeleteContact(contact.ContactID);
        }
        public void DeleteContact(int contactId)
        {
            ContactDAL.DeleteContact(contactId);
        }
        public Contact GetContact(int contactId)
        {
            return ContactDAL.GetContactById(contactId);
        }
        public IEnumerable<Contact> GetContacts()
        {
            return ContactDAL.GetContacts();
        }
        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return ContactDAL.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
        }
        public void SaveContact(Contact contact)
        {
            // Validera affärsreglerna 
            var validationContext = new ValidationContext(contact);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(contact, validationContext, validationResults, true))
            {
                var ex = new ValidationException("Kunden kunde inte sparas.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (contact.ContactID == 0)
            {
                ContactDAL.InsertContact(contact);
            }
            else
            {
                ContactDAL.UpdateContact(contact);  
            }
        }
    }

}