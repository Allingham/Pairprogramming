using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using Xunit;
using FluentAssertions;
using ModelLib;
using Newtonsoft.Json;

namespace XUnitTestRecordsController
{
    public class RecordsControllerTest : ClientInjecter
    {
        [Fact]
        public async void GetAll(){

            //act
            var response = await testClient.GetAsync(URL);
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PostAsync(){

            //arrange
            ModelLib.Record postRecord = new ModelLib.Record(1, "Test Title", "Test Band", 150, 1982, "Test Genre");
            string stringRecord = JsonConvert.SerializeObject(postRecord);
            StringContent recordContent = new StringContent(stringRecord, Encoding.UTF8, "application/json");

            //act
            var response = await testClient.PostAsync(URL, recordContent);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetByIdAsync(){
            Thread.Sleep(1000);
            //act   
            var response = await testClient.GetAsync(URL + "/1");
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PutAsync(){
            Thread.Sleep(1000);
            //arrange
            ModelLib.Record postRecord = new ModelLib.Record("Test Change", "Test Band", 150, 1982, "Test Genre");
            string stringRecord = JsonConvert.SerializeObject(postRecord);
            StringContent recordContent = new StringContent(stringRecord, Encoding.UTF8, "application/json");

            //act
            var response = await testClient.PutAsync(URL + "/1", recordContent);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
