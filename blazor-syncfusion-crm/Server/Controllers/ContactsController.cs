﻿using BlazorSyncfusionCmr.Server.Data;
using BlazorSyncfusionCmr.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCmr.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ContactsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts() 
        {
            return await this.dataContext.Contacts.Where(c => !c.IsDeleted).ToListAsync();        
        }
    }
}
