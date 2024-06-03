using APITesting.Model;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TestFrameworkCore.Helper;

namespace APITesting.Test
{
    [TestClass]
    public class UserAPITest
    {
        private RestClient client;

        [TestInitialize]
        public void TestInitialize()
        {
            var url = ConfigurationHelper.GetConfig<string>("url");
            client = new RestClient(url);
        }

        [TestMethod("TC05: Get List User")]
        public void VerifyGetListUser()
        {
            int randomPage = new Random().Next(1, 11); // lấy 1 đến 10
            var request = new RestRequest($"/api/users?page={randomPage}", Method.Get);
            RestResponse response = client.Execute(request);

            //Status code 200->create
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            GetUserModel model = JsonConvert.DeserializeObject<GetUserModel>(response.Content);
            model.page.Should().Be(randomPage);
        }

        [TestMethod("TC06: Create a new user")]
        public void VerifyCreateNewUser()
        {
            var request = new RestRequest("/api/users", Method.Post);

            //Khai báo model và data để gửi lên api
            var requestModel = new CreateUserRequestModel
            {
                Name = "Hieu" + DateTime.Now.ToFileTimeUtc(),
                Job = "Automation Tester",
            };
            
            request.AddJsonBody(requestModel);
       
            RestResponse response = client.Execute(request);

            // Assertion (Status code 201->create)
            response.StatusCode.Should().Be(HttpStatusCode.Created);


            var reponseModel = JsonConvert.DeserializeObject<CreateUserRequestModel>(response.Content);
            reponseModel.Name.Should().Be(requestModel.Name);    
            reponseModel.Job.Should().Be(requestModel.Job); 
        }
    }
}
