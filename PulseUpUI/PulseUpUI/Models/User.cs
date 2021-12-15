﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PulseUpUI.Models
{
    public class User
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

    }
}
