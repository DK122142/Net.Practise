using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;
using PhoneBook.ViewModels;

namespace PhoneBook.Controllers
{
    [Authorize]
    public class PhoneBookController : Controller
    {
        private readonly IPhoneBookService phoneBookService;
        private readonly IStatusService statusService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public PhoneBookController(IPhoneBookService phoneBookService, IStatusService statusService, IUserService userService, IMapper mapper)
        {
            this.mapper = mapper;
            this.statusService = statusService;
            this.phoneBookService = phoneBookService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var pageSize = 10;

            var count = await this.phoneBookService.TotalCountAsync();

            var records = await this.phoneBookService.GetPageAsync(page, pageSize);

            var pageViewModel = new PageViewModel(count, page, pageSize);

            var viewModel = new PaginationViewModel<PhoneNumberViewModel>
            {
                PageViewModel = pageViewModel,
                Models = this.mapper.Map<IEnumerable<PhoneNumberViewModel>>(records)
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var statuses = await this.statusService.Statuses();
            ViewBag.Statuses = statuses.Select(s => s.StatusType);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhoneNumberViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var record = this.mapper.Map<PhoneNumber>(model);

                    var creatorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                    var statuses = await this.statusService.FindBy(s => s.StatusType.Equals(model.StatusType));

                    if (statuses.Count() > 1)
                    {
                        return View(model);
                    }

                    record.Creator = await this.userService.GetByIdAsync(Guid.Parse(creatorId));
                    record.Added = DateTime.Now;
                    record.Updated = DateTime.Now;
                    record.Status = statuses.FirstOrDefault();
                    
                    await this.phoneBookService.Create(record);

                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var statuses = await this.statusService.Statuses();
            ViewBag.Statuses = statuses.Select(s => s.StatusType);

            var phoneNumber = await this.phoneBookService.GetByIdAsync(id);

            var model = this.mapper.Map<PhoneNumberViewModel>(phoneNumber);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PhoneNumberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var phoneNumber = await this.phoneBookService.GetByIdAsync(model.Id);

                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                if (phoneNumber.Creator.Id != userId)
                {
                    return RedirectToAction("Index");
                }

                var statuses = await this.statusService.FindBy(s => s.StatusType.Equals(model.StatusType));

                if (statuses.Count() > 1)
                {
                    return View(model);
                }

                phoneNumber.Number = model.Number;
                phoneNumber.Address = model.Address;
                phoneNumber.Updated = DateTime.Now;
                phoneNumber.Status = statuses.FirstOrDefault();

                await this.phoneBookService.Update(phoneNumber);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var phoneNumber = await this.phoneBookService.GetByIdAsync(id);

            if (userId == phoneNumber.Creator.Id)
            {
                await this.phoneBookService.DeleteAsync(id);
            }

            return RedirectToAction("Index");
        }
    }
}
