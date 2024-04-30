
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System;
using Midis.Abstract;
using Midis.Domains;
using Microsoft.AspNetCore.Identity;

namespace Midis.BlazorServices
{
    public class ContentService
    {
        protected readonly IRepository<NumberGroup> repositoryGroup;
        protected readonly IRepository<Item> repositoryItem;
        protected readonly IRepository<Schedule> repositorySchedule;
        protected readonly IRepository<UserMidis> repositoryTeacher;


        public ContentService(IRepository<NumberGroup> repositoryGroup, 
            IRepository<Item> repositoryItem, 
            IRepository<Schedule> repositorySchedule,
            IRepository<UserMidis> repositoryTeacher)
        {
            this.repositoryGroup = repositoryGroup;
            this.repositoryItem = repositoryItem;
            this.repositorySchedule = repositorySchedule;
            this.repositoryTeacher = repositoryTeacher;
        }
        public IRepository<NumberGroup> GetRepositoryGroup()
        {
            return repositoryGroup;
        }
        public IRepository<Item> GetRepositoryItem()
        {
            return repositoryItem;
        }
        public IRepository<Schedule> GetRepositorySchedule()
        {
            return repositorySchedule;
        }
        public IRepository<UserMidis> GetRepositoryTeacher()
        {
            return repositoryTeacher;
        }
    }
}
