using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Entities;
using Link_Inventory.Models.Repositories;
using Link_Inventory.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Link_Inventory.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly ISerializedItemRepository _serializedItemRepository;

        public InvoiceController(ApplicationDbContext applicationDbContext, ISupplierRepository supplierRepository, ICompanyRepository companyRepository, IInvoiceRepository invoiceRepository,
            IItemRepository itemRepository, IInvoiceItemRepository invoiceItemRepository, ISerializedItemRepository serializedItemRepository)
        {
            _applicationDbContext = applicationDbContext;
            _supplierRepository = supplierRepository;
            _companyRepository = companyRepository;
            _invoiceRepository = invoiceRepository;
            _itemRepository = itemRepository;
            _invoiceItemRepository = invoiceItemRepository;
            _serializedItemRepository = serializedItemRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewInvoice()
        {
            try
            {
                /*var invoiceItemViewModel = new InvoiceItemsViewModel
                {

   
                };*/

                var suppliers = _supplierRepository.AllSuppliers.Select(s => new
                {
                    Text = s.Name,
                    Value = s.Id
                }).ToList();

                ViewBag.SupplierList = new SelectList(suppliers, "Value", "Text");

                var companies = _companyRepository.AllCompanies.Select(co => new
                {
                    Text = co.Name,
                    Value = co.Id
                }).ToList();

                ViewBag.CompaniesList = new SelectList(companies, "Value", "Text");

                var items = _itemRepository.AllItems.Select(i => new
                {
                    Text = i.Name + "-" + i.Model,
                    Value = i.Id
                }).ToList();
                            

                ViewBag.ItemsList = new SelectList(items, "Value", "Text");

                return View();
            }
            catch(Exception ex)
            {
                return View(ex.Message);

            }
        }

        [HttpPost]
        public IActionResult NewInvoice(Invoice invoice, int supplierId, int companyId)
        {
            try
            {
                var invoiceItemViewModel = new InvoiceItemsViewModel
                {
                    Invoice = _invoiceRepository.AddInvoice(invoice, supplierId, companyId)
                };
                if(invoiceItemViewModel != null)
                {
                    _applicationDbContext.Add(invoiceItemViewModel.Invoice);
                    _applicationDbContext.SaveChanges();
                    return Ok(invoiceItemViewModel.Invoice.Id);
                }
                else
                {
                    return View();
                }
        
            }
            catch (Exception ex)
            {
                return View(ex.Message);

            }
        }

        [HttpPost("/Invoice/NewInvoice1")]
        public JsonResult AddingItems(int invoiceId, int itemId, double price, int amount)
        {
            try
            {
                int typeId = _itemRepository.GetTypeIdByItemId(itemId);
                if(typeId == 1)
                {
                    var newInvoiceItemsViewModel = new InvoiceItemsViewModel
                    {
                        InvoiceItem = _invoiceItemRepository.AddInvoiceItem(invoiceId, itemId, price, amount),
                    };

                    newInvoiceItemsViewModel.NewSerializedItems = _serializedItemRepository.NewSerializedItems(itemId, amount, newInvoiceItemsViewModel.InvoiceItem.Id);
                    newInvoiceItemsViewModel.InvoiceItem.Invoice = _invoiceRepository.GetInvoiceById(invoiceId);



                    return Json(newInvoiceItemsViewModel);
                    
                }
                else
                {
                    var nonSerializedInvoiceItems = new InvoiceItemsViewModel
                    {
                        Item = _itemRepository.UpdateItem(itemId, amount),
                        InvoiceItem = _invoiceItemRepository.AddInvoiceItem(invoiceId, itemId, price, amount),
                    };

                    return Json(nonSerializedInvoiceItems);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.Message);

            }
        }
        [HttpGet]
        public IActionResult InvoiceSummary(int invoiceId)
        {
            try
            {
                InvoiceItemsViewModel invoiceViewModel = new InvoiceItemsViewModel()
                {
                    InvoiceItemsByInvoiceId = _invoiceItemRepository.InvoiceSummaryByInvoiceId(invoiceId)
                };

                return View(invoiceViewModel);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }

  
        }

        [HttpGet("/Invoice/NewInvoice2/{invoiceItemId}")]
        public JsonResult RemoveInvoiceItem(int invoiceItemId)
        {
            var invoiceViewModel = new InvoiceItemsViewModel()
            {
                SuccessfullyRemovedInvoiceItem = _invoiceItemRepository.RemoveInvoiceItem(invoiceItemId)
            };

            return Json(invoiceViewModel.SuccessfullyRemovedInvoiceItem);
        }






    }
}
