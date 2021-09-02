using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using PardakhtYar.Shaparak.Models;
using PardakhtYar.Shaparak.Infrastructure;

namespace PardakhtYar.Shaparak {

    ///<inheritdoc/>
    public class ShaparakClient : IShaparakClient {

        private readonly IHttpRestClient _client;

        /// <summary>
        /// Pass <see cref="Username"/> and <see cref="Password"/> in plain text.
        /// This class will convert it to Base64 in order to build Basic Authorization header
        /// for Shaparak WebService.
        /// </summary>
        /// <param name="username">Shaparak Username</param>
        /// <param name="password">Shaparak Password</param>
        public ShaparakClient(IHttpRestClient client,
            string baseUrl,
            string username,
            string password) {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            BaseUrl = baseUrl;
            Username = username;
            Password = password;
        }

        #region Constants

        private const string URL_READ_REQUEST = "webService/readRequestCartableWithFilter";
        private const string URL_WRITE_REQUEST = "webService/writeExternalRequest";

        #endregion

        #region Properties

        /// <inheritdoc/>
        public string BaseUrl {
            get => _baseUrl;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(BaseUrl));
                _baseUrl = value;
            }
        }
        private string _baseUrl;

        /// <inheritdoc/>
        public string Username {
            get => _username;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(Username));
                _username = value;
            }
        }
        private string _username;

        /// <inheritdoc/>
        public string Password {
            get => _password;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(Password));
                _password = value;
            }
        }
        private string _password;

        #endregion

        /// <inheritdoc/>
        public async Task<ShaparakReadRequestCartableResponse> ReadRequestCartableAsync(ShaparakReadRequest model) {
            if (model == null)
                throw new NullReferenceException("The model cannot be null.");

            ShaparakReadRequestCartableResponse result;

            result = await _client
                .PostAsync<ShaparakReadRequest, ShaparakReadRequestCartableResponse>
                    (model, getUrl(URL_READ_REQUEST), getHeaders());

            return result;
        }

        /// <inheritdoc/>
        public async Task<ShaparakWriteResponse> WriteExternalRequestAsync(ShaparakWriteRequest model) {
            if (model == null)
                throw new NullReferenceException("The model cannot be null.");

            ShaparakWriteResponse result;

            result = await _client
                .PostAsync<ShaparakWriteRequest, ShaparakWriteResponse>
                    (model, getUrl(URL_WRITE_REQUEST), getHeaders());

            return result;
        }

        #region Helper Methods

        private string getUrl(string servicePath)
            => BaseUrl.EndsWith("/") 
                    ? $"{BaseUrl}{servicePath}" 
                    : $"{BaseUrl}/{servicePath}";

        private string base64Encode(string what)
            => Convert.ToBase64String(Encoding.ASCII.GetBytes(what));

        private string getAuthorizationValue() =>
             $"Basic {base64Encode($"{Username}:{Password}")}";

        private Dictionary<string, string> getHeaders() =>
            new Dictionary<string, string>
            {
                { "Authorization", getAuthorizationValue() },
                { "Content-Type", "application/json" },
                { "Accept", "*/*" }, //Tell the server that this client will accept any format
                { "Connection", "keep-alive" },
                { "User-Agent", "PardakhtYar" }
            };

        #endregion

    }
}
