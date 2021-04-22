using AddressBookSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace RestSharpAddressBookTestProject
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:3000");
        }
        private IRestResponse getContactsList()
        {
            RestRequest request = new RestRequest("/Contacts", Method.GET);

            //act

            IRestResponse response = client.Execute(request);
            return response;
        }
        //UC22
        [TestMethod]
        public void onCallingGETApi_ReturnContactsList()
        {
            IRestResponse response = getContactsList();

            //assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            List<ContactsModel> dataResponse = JsonConvert.DeserializeObject<List<ContactsModel>>(response.Content);
            Assert.AreEqual(8, dataResponse.Count);
            foreach (var item in dataResponse)
            {
                System.Console.WriteLine( "First Name: " + item.First_name +"\t" +"Last Name: " + item.Last_name);
            }
        }
<<<<<<< HEAD
        //UC23
        [TestMethod]
        public void givenContacts_OnPost_ShouldReturnAddedContacts()
        {
            RestRequest request = new RestRequest("/Contacts", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("First_name", "Clark");
            jObjectbody.Add("Last_name", "Dsoza");
            jObjectbody.Add("Address", "kj road");
            jObjectbody.Add("City", "NY");
            jObjectbody.Add("State", "bst");
            jObjectbody.Add("Zip", "123445");
            jObjectbody.Add("Phone_number", "9999979000");
            jObjectbody.Add("Email", "cdd@gmail.com");
            jObjectbody.Add("AddressBookName", "AddressBook1");
=======
        [TestMethod]
        public void givenContacts_OnPUT_ShouldReturnAddedContacts()
        {
            RestRequest request = new RestRequest("/Contacts/1", Method.PUT);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("First_name", "Ansh");
            jObjectbody.Add("Last_name", "Usrete");
            jObjectbody.Add("Address", "ravi nagar");
            jObjectbody.Add("City", "amt");
            jObjectbody.Add("State", "telangana");
            jObjectbody.Add("Zip", "123445");
            jObjectbody.Add("Phone_number", "99999999000");
            jObjectbody.Add("Email", "au@gmail.com");            
            jObjectbody.Add("aaaa", "AddressBook1");
>>>>>>> UC24-UpdateEntryinJsonServer
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //act
            IRestResponse response = client.Execute(request);
<<<<<<< HEAD
            Assert.AreEqual( System.Net.HttpStatusCode.Created, response.StatusCode);
            JsonContactsModel dataResponse = JsonConvert.DeserializeObject<JsonContactsModel>(response.Content);
            Assert.AreEqual("Clark", dataResponse.First_name);
            Assert.AreEqual("Dsoza", dataResponse.Last_name);
            Assert.AreEqual("kj road", dataResponse.Address);
            Assert.AreEqual("NY", dataResponse.City);
            Assert.AreEqual("bst", dataResponse.State);
            Assert.AreEqual("123445", dataResponse.Zip);
            Assert.AreEqual("9999979000", dataResponse.Phone_number);
            Assert.AreEqual("cdd@gmail.com", dataResponse.Email);
            Assert.AreEqual("AddressBook1", dataResponse.AddressBookName);

=======
            Assert.AreEqual( System.Net.HttpStatusCode.OK, response.StatusCode);
            JsonContactsModel dataResponse = JsonConvert.DeserializeObject<JsonContactsModel>(response.Content);
            Assert.AreEqual("Ansh", dataResponse.First_name);
            Assert.AreEqual("Usrete", dataResponse.Last_name);
            Assert.AreEqual("ravi nagar", dataResponse.Address);
            Assert.AreEqual("amt", dataResponse.City);
            Assert.AreEqual("telangana", dataResponse.State);
            Assert.AreEqual("123445", dataResponse.Zip);
            Assert.AreEqual("99999999000", dataResponse.Phone_number);
            Assert.AreEqual("au@gmail.com", dataResponse.Email);
            Console.WriteLine("Contact Updated successfully...");            
>>>>>>> UC24-UpdateEntryinJsonServer
        }
    }
}
