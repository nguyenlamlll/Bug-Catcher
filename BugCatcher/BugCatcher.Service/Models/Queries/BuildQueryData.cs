﻿using BugCatcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Service.Models.Queries
{
    public class BuildQueryData
    {
        public BuildQueryData()
        {

        }
        public BuildQueryData(Build build)
        {
            Id = build.Id;
            Name = build.Name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}