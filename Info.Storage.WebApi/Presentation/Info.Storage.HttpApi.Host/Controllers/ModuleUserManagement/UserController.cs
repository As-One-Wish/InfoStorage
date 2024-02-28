﻿using Info.Storage.Application.ModuleUserManagement;
using Info.Storage.Infa.Entity.ModuleUserManagement.Dtos;
using Info.Storage.Infa.Entity.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Info.Storage.HttpApi.Host.Controllers.ModuleUserManagement
{
    [Route("api/[controller]")]
    [Authorize(Policy = "Policy.Default")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Initialize

        private readonly IUserService _userService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion Initialize

        [HttpPost]
        [Route("AddUser")]
        [ProducesResponseType(typeof(BaseResult<UserDto?>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto, [FromQuery] bool responseData = false)
        {
            BaseResult<UserDto?> br = await this._userService.AddUser(userDto, responseData);
            return Ok(br);
        }
    }
}