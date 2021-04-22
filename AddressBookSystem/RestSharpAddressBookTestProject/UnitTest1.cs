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
        [TestMethod]
        public void givenContacts_OnPost_ShouldReturnAddedContacts()
        {
            RestRequest request = new RestRequest("/Contacts", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("First_name", "Clark");
            jObjectbody.Add("Last_name", "Dsoza");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //act
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
            ContactsModel dataResponse = JsonConvert.DeserializeObject<ContactsModel>(response.Content);
            Assert.AreEqual("Clark", dataResponse.First_name);
            Assert.AreEqual("Dsoza", dataResponse.Last_name);

        }
    }
}
