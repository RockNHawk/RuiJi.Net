﻿using Newtonsoft.Json;
using RuiJi.Net.Core.Crawler;
using RuiJi.Net.Core.Extensions;
using RuiJi.Net.Core.Extractor;
using RuiJi.Net.Core.Extractor.Selector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuiJi.Net.Node.Feed.Db
{
    public enum RuleTypeEnum
    {
        HTML,
        JSON,
        JSONP,
        XML
    }

    public class RuleModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(EnumConvert<RuleTypeEnum>))]
        public RuleTypeEnum Type { get; set; }

        [JsonProperty("expression")]
        public string Expression { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("postParam")]
        public string PostParam { get; set; }

        [JsonProperty("ua")]
        public string UA { get; set; }

        [JsonProperty("headers")]
        public string Headers { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("feature")]
        public string Feature { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(EnumConvert<Status>))]
        public Status Status { get; set; }

        [JsonProperty("runJs")]
        [JsonConverter(typeof(EnumConvert<Status>))]
        public Status RunJS { get; set; }

        [JsonProperty("waitDom")]
        public string WaitDom { get; set; }

        [JsonProperty("block")]
        public string BlockExpression { get; set; }

        [JsonProperty("rexp")]
        public string RuiJiExpression { get; set; }
    }
}