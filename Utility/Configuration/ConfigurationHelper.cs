using AutoMapper.Execution;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using WarOfRightsWeb.Models;

namespace WarOfRightsWeb.Utility.Configuration
{
    public class ConfigurationHelper
    {
        // any options here?
        private readonly IWebHostEnvironment _hostingEnvironment;
        public readonly IConfiguration Configuration;

        public ConfigurationHelper(IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            Configuration = configuration;
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
