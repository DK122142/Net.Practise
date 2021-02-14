using System;
using System.IO;
using EducationPortalADO.DAL.Infrastructure;
using EducationPortalADO.DAL.Repositories;
using EducationPortalADO.DAL.Services;
using Microsoft.Extensions.Configuration;

namespace EducationPortalADO.DAL.Views
{
    public class Start
    {
        public Start()
        {
            Home.Home.Show();
        }
    }
}
