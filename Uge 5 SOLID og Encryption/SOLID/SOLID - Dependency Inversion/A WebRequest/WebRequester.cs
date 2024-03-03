using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_WebRequest
{

    internal class WebRequester
    {
        HttpClient _sharedClient; // Prepare a variable to hold the shared HttpClient
        IOutput _outputMethod; // Prepare a variable to hold the chosen implementation of IOutput
        public WebRequester( HttpClient sharedClient, IOutput outputMethod) // Dependency Injection
        {
             _sharedClient = sharedClient;
            _outputMethod = outputMethod;
        }

        public void SetBaseAddress(string baseAddress)
        {
            _sharedClient.BaseAddress = new Uri(baseAddress); // Configure the base address of the shared client
        }

        public async Task GetAsync(string requestUri)
        {
            try
            {
                var response = await _sharedClient.GetAsync(requestUri); // Send a GET request to the specified Uri
                response.EnsureSuccessStatusCode(); // Throw an exception if the status code is unsuccessful
                _outputMethod.Write(await response.Content.ReadAsStringAsync()); // Write the result to the chosen output method
            }
            catch (Exception)
            {
                Console.Out.WriteLineAsync("Something went wrong while hitting the web. Or writing the result.");
                throw;
            }
            
        }
    }
}
