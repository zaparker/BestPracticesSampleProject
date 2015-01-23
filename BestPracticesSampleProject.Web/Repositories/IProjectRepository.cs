﻿using BestPracticesSampleProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPracticesSampleProject.Web.Repositories
{
    /// <summary>
    /// Defines the CRUD operations for a project repository.
    /// </summary>
    public interface IProjectRepository : IRepository<Project>
    {
    }
}
