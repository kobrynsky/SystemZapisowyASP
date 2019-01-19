using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services.Interfaces;

namespace SystemZapisowy.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupsService()
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
        }
    }
}