﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugCatcher.Service.Models.Commands
{
    public class CreateBuildCommand
    {
        [DisplayName("Version")]
        public string Name { get; set; }

        public Guid ProductId { get; set; }
        
    }
}