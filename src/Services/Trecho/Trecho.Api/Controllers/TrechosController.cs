﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Trecho.Api.Models;
using Trecho.Api.ServiceClient;

namespace Trecho.Api.Controllers
{
    [Route("api/trechos")]
    public class TrechosController : Controller
    {
        private readonly IMongoDatabase _database = null;
        private readonly ILevantamentoService _apiClient;
        public TrechosController(IOptions<DataSettings> settings, ILevantamentoService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _database.GetCollection<TrechoDTO>("Trecho").Find(new BsonDocument()).ToListAsync();
            return Ok(result);
        }
    }
}