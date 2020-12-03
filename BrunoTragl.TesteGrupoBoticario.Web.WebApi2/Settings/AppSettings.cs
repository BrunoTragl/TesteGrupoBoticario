﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Settings
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public double ExpirationTime { get; set; }
        public string Emitter { get; set; }
        public string ValidIn { get; set; }
    }
}
