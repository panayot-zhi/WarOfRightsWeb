using AutoMapper.Execution;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using WarOfRightsWeb.Models;

namespace WarOfRightsWeb.Utility.Configuration
{
    public class ConfigurationHelper
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ConfigurationHelper(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public CompanyMembers GetCompanyDiscordMembers()
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "discordMembers.json");
            var jsonContent = File.ReadAllText(filePath);
            var companyMembers = JsonConvert.DeserializeObject<CompanyMembers>(jsonContent);

            return companyMembers;
        }

        public CompanyMember GetCompanyDiscordMember(ulong id)
        {
            var companyMembers = GetCompanyDiscordMembers();

            return companyMembers.Members.SingleOrDefault(x => x.Id == id);
        }
    }
}
