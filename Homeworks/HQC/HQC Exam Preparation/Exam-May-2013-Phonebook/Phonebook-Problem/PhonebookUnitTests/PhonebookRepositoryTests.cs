namespace PhonebookUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook;

    [TestClass]
    public class PhonebookRepositoryTests
    {
        [TestMethod]
        public void CheckEntriesCountWhenOnePhoneIsAdded()
        {
            var name = "Katrina";
            var phones = new string[] { " +359899777235", " +359899777235" };
            var phoneRepository = new PhonebookRepository();

            phoneRepository.AddPhone(name, phones);

            Assert.AreEqual(phoneRepository.EntriesCount, 1);
        }

        [TestMethod]
        public void CheckPhonesCountWhenOnePhoneIsAdded()
        {
            var name = "Katrina";
            var phones = new string[] { " +359899777235", " +359899777235" };
            var phoneRepository = new PhonebookRepository();

            phoneRepository.AddPhone(name, phones);

            Assert.AreEqual(phoneRepository.PhonesCount, 1);
        }

        [TestMethod]
        public void CheckEntriesCountWhenEntriesDuplicate()
        {
            var name = "Katrina";
            var phones = new string[] { " +359899777235", " +359899777235" };
            var dublicateName = "Katrina";
            var dublicatePhones = new string[] { " +359899777235", " +359899777235" };
            var phoneRepository = new PhonebookRepository();

            phoneRepository.AddPhone(name, phones);
            phoneRepository.AddPhone(dublicateName, dublicatePhones);

            Assert.AreEqual(phoneRepository.EntriesCount, 1);
        }

        [TestMethod]
        public void CheckPhonesCountWhenEntriesDuplicate()
        {
            var name = "Katrina";
            var phones = new string[] { " +359899777235", " +359899777235" };
            var dublicateName = "Katrina";
            var dublicatePhones = new string[] { " +359899777235", " +359899777235" };
            var phoneRepository = new PhonebookRepository();

            phoneRepository.AddPhone(name, phones);
            phoneRepository.AddPhone(dublicateName, dublicatePhones);

            Assert.AreEqual(phoneRepository.PhonesCount, 1);
        }

        [TestMethod]
        public void CheckEntriesCountWhenEntriesDuplicateWithDifferentCasting()
        {
            var name = "Katrina";
            var phones = new string[] { " +359899777235", " +359899777235" };
            var dublicateName = "KaTrInA";
            var capsName = "KATRINA";
            var phoneRepository = new PhonebookRepository();

            phoneRepository.AddPhone(name, phones);
            phoneRepository.AddPhone(dublicateName, phones);
            phoneRepository.AddPhone(capsName, phones);

            Assert.AreEqual(phoneRepository.EntriesCount, 1);
        }

        [TestMethod]
        public void CheckPhonesCountWhenEntriesDuplicateWithDifferentCasting()
        {
            var name = "Katrina";
            var phones = new string[] { " +359899777235", " +359899777235" };
            var dublicateName = "KaTrInA";
            var capsName = "KATRINA";
            var phoneRepository = new PhonebookRepository();

            phoneRepository.AddPhone(name, phones);
            phoneRepository.AddPhone(dublicateName, phones);
            phoneRepository.AddPhone(capsName, phones);

            Assert.AreEqual(phoneRepository.PhonesCount, 1);
        }
    }
}
