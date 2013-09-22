using System.Web.Http;
using FluentKnockoutHelpers.Core;
using FluentKnockoutHelpers.Core.TypeMetadata;
using Newtonsoft.Json;

namespace SurveyApp.Web.Codegen
{
    public class JsMetadataGenerator
    {
        public static string Generate()
        {
            GlobalSettings.JsonSerializer = new JsonDotNetSerializer();
            var helper = new TypeMetadataHelper();
            helper.BuildForAllEndpointSubclassesOf<ApiController>();
            return helper.GetMetadata();
        }
    }

    public class JsonDotNetSerializer : IJsonSerializer
    {
        public string ToJsonString(object toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize);
        }

        public bool SerializerRequiresAssembly
        {
            get { return true; }
        }
    }
}