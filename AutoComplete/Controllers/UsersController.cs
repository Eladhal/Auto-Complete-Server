using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoComplete.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AutoComplete.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public userInfo[] search(string term)
        {
            string allText = System.IO.File.ReadAllText(@"C:\Users\User\Desktop\AutoComplete\AutoComplete\Content\users.json");
            userInfo[] jsonObj = JsonConvert.DeserializeObject<userInfo[]>(allText);
            userInfo[] returnUsers = jsonObj.Where(user => user.name.IndexOf(term) != -1 || user.workTitle.IndexOf(term) != -1).ToArray();

            return returnUsers;
        }
    }
}