// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using Payments.Model.Models;

var user = new User()
{
    Info = new UserInfo()
    {
        Age = 10,
        Comment = "My User Comment",
    },
    Name = "UserName"
};

var trans = new Transaction()
{
    CreatedDate = DateTime.UtcNow
};

var url = "http://localhost:5000/payments/";
var httpClient = new HttpClient(){BaseAddress = new Uri(url)};

var content = new StringContent(JsonConvert.SerializeObject(trans), Encoding.UTF8, "application/json");
var response = await httpClient.PostAsJsonAsync($"createUser", user);
if (response.IsSuccessStatusCode)
{
    var createdUser = await response.Content.ReadFromJsonAsync<User>();
    Console.WriteLine(createdUser);
}

Console.WriteLine("Hello, World!");